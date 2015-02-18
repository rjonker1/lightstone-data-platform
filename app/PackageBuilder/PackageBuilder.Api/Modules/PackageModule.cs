using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using AutoMapper;
using DataPlatform.Shared.Enums;
using Nancy;
using Nancy.ModelBinding;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.CommandHandlers;
using PackageBuilder.Domain.Dtos.WriteModels;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;
using PackageBuilder.Domain.Entities.DataProviders.WriteModels;
using PackageBuilder.Domain.Entities.Packages.Commands;
using PackageBuilder.Domain.Entities.Packages.WriteModels;
using PackageBuilder.Domain.Entities.States.WriteModels;
using PackageBuilder.TestObjects.Mothers;


namespace PackageBuilder.Api.Modules
{
    public class PackageModule : NancyModule
    {
        public PackageModule(IPublishStorableCommands publisher,
            IRepository<Domain.Entities.Packages.ReadModels.Package> readRepo,
            INEventStoreRepository<Package> writeRepo, IRepository<State> stateRepo)
        {
            Get["/Packages"] = parameters =>
                Response.AsJson(readRepo.Where(x => !x.IsDeleted));

            Get["/Packages/{id}/{version}"] = parameters =>
                Response.AsJson(
                    new
                    {
                        Response =
                            new[]
                            {Mapper.Map<IPackage, PackageDto>(writeRepo.GetById(parameters.id, parameters.version))}
                    });

            Get["/Packages/Package/{id}"] = parameters =>
            {
                PackageDto package = Mapper.Map<IPackage, PackageDto>(writeRepo.GetById(parameters.id));


                if (package == null)
                    throw new Exception("Package could not be found");

                var dataProviders = GetSelectedDataProvidersForSearchRequest(package);

                //TODO: Building Request Package here is not the best place. Should come already built from Read Side together with its ACTION??
                var requestPackage = new Package(package.Id, package.Name, ActionMother.LicensePlateSearchAction,
                    dataProviders.Select(
                        s =>
                            new DataProvider(s.Id, (DataProviderName) Enum.Parse(typeof (DataProviderName), s.Name),
                                s.Description, s.CostOfSale, null,
                                s.FieldLevelCostPriceOverride, s.Owner, s.CreatedDate, s.EditedDate,
                                s.DataFields.Select(
                                    d =>
                                        new DataField(d.Name, d.Type, d.Definition, d.Industries, d.Price,
                                            d.IsSelected.HasValue ? d.IsSelected.Value : false)))));

                return Response.AsJson(requestPackage);
            };

            Post["/Packages"] = parameters =>
            {
                var dto = this.Bind<PackageDto>();
                var dProviders =
                    Mapper.Map<IEnumerable<DataProviderDto>, IEnumerable<DataProviderOverride>>(dto.DataProviders);

                publisher.Publish(new CreatePackage(Guid.NewGuid(), dto.Name, dto.Description, dto.CostOfSale,
                    dto.RecommendedSalePrice, dto.Notes, dto.Industries, dto.State, dto.Owner, DateTime.UtcNow, null,
                    dProviders));

                return Response.AsJson(new {msg = "Success"});
            };

            Put["/Packages/{id}"] = parameters =>
            {
                var dto = this.Bind<PackageDto>();
                var dProviders =
                    Mapper.Map<IEnumerable<DataProviderDto>, IEnumerable<DataProviderOverride>>(dto.DataProviders);

                publisher.Publish(new UpdatePackage(parameters.id, dto.Name, dto.Description, dto.CostOfSale,
                    dto.RecommendedSalePrice, dto.Notes, dto.Industries, dto.State, dto.Version, dto.Owner,
                    dto.CreatedDate, DateTime.UtcNow, dProviders));

                return Response.AsJson(new {msg = "Success, " + parameters.id + " edited"});
            };

            Put["/Packages/Clone/{id}/{cloneName}"] = parameters =>
            {
                var packageToClone = Mapper.Map<IPackage, PackageDto>(writeRepo.GetById(parameters.id));
                var dataProvidersToClone =
                    Mapper.Map<IEnumerable<DataProviderDto>, IEnumerable<DataProviderOverride>>(
                        packageToClone.DataProviders);
                var stateResolve = stateRepo.Where(x => x.Alias == "Draft")
                    .Select(y => new State(y.Id, y.Name, y.Alias));

                publisher.Publish(new CreatePackage(Guid.NewGuid(),
                    parameters.cloneName,
                    packageToClone.Description,
                    packageToClone.CostOfSale,
                    packageToClone.RecommendedSalePrice,
                    packageToClone.Notes,
                    packageToClone.Industries,
                    stateResolve.FirstOrDefault(),
                    packageToClone.Owner, DateTime.UtcNow, null,
                    dataProvidersToClone));

                return
                    Response.AsJson(
                        new
                        {
                            msg =
                                "Success, Package with ID: " + parameters.id + " has been cloned to package '" +
                                parameters.cloneName + "'"
                        });
            };

            Delete["/Packages/Delete/{id}"] = parameters =>
            {
                publisher.Publish(new DeletePackage(new Guid(parameters.id)));

                return Response.AsJson(new {msg = "Success, " + parameters.id + " deleted"});
            };
        }

        private static IEnumerable<DataProviderDto> GetSelectedDataProvidersForSearchRequest(PackageDto package)
        {
            var dataProviderList = new List<DataProviderDto>();

            foreach (var dataProvider in package.DataProviders)
            {

                CheckForSelectedDataFields(dataProvider.DataFields.ToList(), dataProviderList,
                    dataProvider);
            }

            return dataProviderList;
        }


        private static bool CheckForSelectedDataFields(IEnumerable<DataProviderFieldItemDto> dataFields,
            ICollection<DataProviderDto> dataProviderList, DataProviderDto dataProvider)
        {
            Debug.Write("\n\n***********************");
            Debug.Write(string.Format("\nData Provider {0}", dataProvider.Name));

            foreach (var field in dataFields)
            {
                var isSelected = field.IsSelected != null && field.IsSelected.Value ||
                                 field.DataFields.FirstOrDefault(
                                     w => w.IsSelected != null && w.IsSelected.Value) != null;

                Debug.Write(string.Format("\n{0} has selected datafields or is selected? {1} Fields Selected Value {2}",
                    field.Name, isSelected, field.IsSelected));

                if (isSelected)
                {
                    dataProviderList.Add(dataProvider);
                    return true;
                }

                Debug.Write("\n++++++++++++++++++++++++++++++++++++++++");
                Debug.Write("\nContinue to next list.....");
                var stop = CheckForSelectedDataFields(field.DataFields.ToList(), dataProviderList, dataProvider);

                if (stop)
                    return true;
            }

            Debug.Write("\n========================================");
            Debug.Write("\nReturning false.....");
            return false;
        }
    }
}