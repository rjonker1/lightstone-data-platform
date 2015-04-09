using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataPlatform.Shared.ExceptionHandling;
using Lace.Domain.Infrastructure.Core.Contracts;
using Nancy;
using Nancy.Json;
using Nancy.ModelBinding;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.CommandHandlers;
using PackageBuilder.Domain.Dtos.Read;
using PackageBuilder.Domain.Dtos.Write;
using PackageBuilder.Domain.Entities.Contracts.Packages.Write;
using PackageBuilder.Domain.Entities.DataProviders.Write;
using PackageBuilder.Domain.Entities.Packages.Commands;
using PackageBuilder.Domain.Entities.States.Read;
using PackageBuilder.TestObjects.Mothers;
using Shared.BuildingBlocks.Api.Security;
using DataProviderDto = PackageBuilder.Domain.Dtos.Write.DataProviderDto;
using Package = PackageBuilder.Domain.Entities.Packages.Write.Package;

namespace PackageBuilder.Api.Modules
{
    public class PackageModule : SecureModule
    {
        private static int _defaultJsonMaxLength;
        public PackageModule(IPublishStorableCommands publisher,
            IRepository<Domain.Entities.Packages.Read.Package> readRepo,
            INEventStoreRepository<Package> writeRepo, IRepository<State> stateRepo, IEntryPoint entryPoint)
        {
            if (_defaultJsonMaxLength == 0)
                _defaultJsonMaxLength = JsonSettings.MaxJsonLength;

            //Hackeroonie - Required, due to complex model structures (Nancy default restriction length [102400])
            JsonSettings.MaxJsonLength = Int32.MaxValue;

            Get["/Packages"] = parameters =>
                Response.AsJson(readRepo.Where(x => !x.IsDeleted));

            Get["/Packages/{filter}"] = parameters =>
            {
                string filter = (parameters.filter + "").Trim().ToLower();

                return Response.AsJson(readRepo.Where(x => !x.IsDeleted && (x.Name + "").Trim().ToLower().StartsWith(filter)));
            };

            Get["/Packages/{id}/{version}"] = parameters =>
                Response.AsJson(
                    new
                    {
                        Response =
                            new[]
                            {Mapper.Map<IPackage, PackageDto>(writeRepo.GetById(parameters.id, parameters.version))}
                    });

            Get["/Packages/Execute/{id}/{userId}/{searchTerm}/{requestId}"] = parameters =>
            {
                //Guid id = (Guid) parameters.id;
                var package = writeRepo.GetById(parameters.id);// Mapper.Map<IPackage, PackageDto>(writeRepo.GetById(parameters.id));

                if (package == null)
                    throw new LightstoneAutoException("Package could not be found");

                //var dto = new DataProviderRequestDto(package.Id, package.Name, ActionMother.LicensePlateSearchAction);
                //dto.SetDataProviders(package);

                //var request = package.FormLaceRequest(parameters.userId, parameters.username, parameters.searchTerm, "", parameters.requestId);

                //var responses = entryPoint.GetResponsesFromLace(request);

                var responses = package.Execute(entryPoint, parameters.userId, parameters.username, parameters.searchTerm, "", parameters.requestId);
                //return Response.AsJson(model);

                return responses;
            };

            //TODO: This route must be removed. Data Provider pacakges should all come through /Packages/DataProvider/{id
            Get["/Packages/DataProvider/ForPropertySearch/{id}"] = parameters =>
            {
                PackageDto package = Mapper.Map<IPackage, PackageDto>(writeRepo.GetById(parameters.id));

                if (package == null)
                    throw new LightstoneAutoException("Package could not be found");

                var dto = new DataProviderRequestDto(package.Id, package.Name, ActionMother.PropertyVerificationAction);
                dto.SetDataProviders(package);

                return Response.AsJson(dto);
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