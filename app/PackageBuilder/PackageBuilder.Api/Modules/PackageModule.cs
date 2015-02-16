using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Nancy;
using Nancy.ModelBinding;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.CommandHandlers;
using PackageBuilder.Domain.Dtos.WriteModels;
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

            Get["/Package/{id}"] = parameters =>
            {
                IPackage package = Mapper.Map<IPackage, PackageDto>(writeRepo.GetById(parameters.id));

                //TODO: Remove Fake Action Request Items
                var requestPackage = new Package(package.Id, package.Name, ActionMother.LicensePlateSearchAction,
                    package.DataProviders.Select(
                        s =>
                            new DataProvider(s.Id, s.Name, s.Description, s.CostOfSale, s.ResponseType,
                                s.FieldLevelCostPriceOverride, s.Owner, s.CreatedDate, s.EditedDate, s.DataFields)));

                return Response.AsJson(new {Response = requestPackage});
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
    }
}