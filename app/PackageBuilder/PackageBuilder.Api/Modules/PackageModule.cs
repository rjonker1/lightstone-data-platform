using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using DataPlatform.Shared.Dtos;
using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using DataPlatform.Shared.Messaging.Billing.Helpers;
using DataPlatform.Shared.Messaging.Billing.Messages;
using EasyNetQ;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Shared.Extensions;
using Lim.Domain.Messaging.Messages;
using Lim.Domain.Messaging.Publishing;
using Nancy;
using Nancy.Json;
using Nancy.ModelBinding;
using PackageBuilder.Core.Helpers;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.CommandHandlers;
using PackageBuilder.Domain.Dtos.Read;
using PackageBuilder.Domain.Dtos.Write;
using PackageBuilder.Domain.Entities.Contracts.Packages.Write;
using PackageBuilder.Domain.Entities.DataProviders.Write;
using PackageBuilder.Domain.Entities.Enums.States;
using PackageBuilder.Domain.Entities.Packages.Commands;
using PackageBuilder.Domain.Entities.States.Read;
using PackageBuilder.TestObjects.Mothers;
using Shared.BuildingBlocks.Api.ApiClients;
using DataProviderDto = PackageBuilder.Domain.Dtos.Write.DataProviderDto;
using Package = PackageBuilder.Domain.Entities.Packages.Write.Package;
using StringExtensions = ServiceStack.Text.StringExtensions;

namespace PackageBuilder.Api.Modules
{
    public class PackageModule : NancyModule// : SecureModule
    {
        private static int _defaultJsonMaxLength;
        public PackageModule(IPublishStorableCommands publisher,
            IRepository<Domain.Entities.Packages.Read.Package> readRepo,
            INEventStoreRepository<Package> writeRepo, IRepository<State> stateRepo, IEntryPoint entryPoint, IAdvancedBus eBus, IUserManagementApiClient userManagementApi,IPublishIntegrationMessages integration)
        {
            if (_defaultJsonMaxLength == 0)
                _defaultJsonMaxLength = JsonSettings.MaxJsonLength;

            //Hackeroonie - Required, due to complex model structures (Nancy default restriction length [102400])
            JsonSettings.MaxJsonLength = Int32.MaxValue;

            Get["/Packages"] = parameters =>
                Response.AsJson(readRepo.Where(x => !x.IsDeleted));

            Get["/Packages/{filter?}/{pageIndex:int}/{pageSize:int}"] = parameters =>
            {
                string filter = (parameters.filter + "").Trim().ToLower();
                Expression<Func<Domain.Entities.Packages.Read.Package, bool>> predicate = x => !x.IsDeleted && (x.Name + "").Trim().ToLower().StartsWith(filter);
                predicate = package => true;

                //var publishedPackages = from p in readRepo
                //                        where p.Id == (from pp in readRepo
                //                                       where p.State.Name == StateName.Published
                //                                       orderby pp.Version descending
                //                                       select pp.Id).FirstOrDefault()
                //                        select p;

                var packagesTest = readRepo.Where(x => x.State.Name == StateName.Published).OrderByDescending(d => d.Version);

                var publishedPackagesList = new List<Domain.Entities.Packages.Read.Package>();

                foreach (var package in packagesTest)
                {

                    var index = publishedPackagesList.FindIndex(x => x.PackageId == package.PackageId);

                    if (index < 0) publishedPackagesList.Add(package);
                    foreach (var pubPackage in publishedPackagesList)
                    {
                        if (package.Version > pubPackage.Version)
                        {
                            publishedPackagesList.Remove(pubPackage);
                            publishedPackagesList.Add(package);
                        }
                    }
                }

                var publishedPackages = publishedPackagesList.AsQueryable();

                var packages = new PagedList<Domain.Entities.Packages.Read.Package>(publishedPackages, 
                                                parameters.pageIndex, parameters.pageSize, predicate);
                return Response.AsJson(
                        new
                        {
                            data = packages,
                            pageIndex = packages.PageIndex,
                            pageSize = packages.PageSize,
                            pageTotal = packages.PageTotal,
                            recordsTotal = packages.RecordsTotal,
                            recordsFiltered = packages.RecordsFiltered
                        });
            };

            Get["/Packages/{id:guid}/{version:int}"] = parameters =>
                Response.AsJson(
                    new
                    {
                        Response = new[]{Mapper.Map<IPackage, PackageDto>(writeRepo.GetById(parameters.id, parameters.version))}
                    });

            Post["/Packages/Execute"] = parameters =>
            {
                var apiRequest = this.Bind<ApiRequestDto>();

                var package = writeRepo.GetById(apiRequest.PackageId);

                if (package == null)
                {
                    this.Error(() => "Package not found:".FormatWith(apiRequest.PackageId));
                    throw new LightstoneAutoException("Package could not be found");
                }

                var token = Context.Request.Headers.Authorization.Split(' ')[1];
                var resource = string.Format("CustomerClient/{0}", apiRequest.CustomerClientId);
                var accountNumber = userManagementApi.Get("", resource, "", new[] { new KeyValuePair<string, string>("Authorization", "Token " + token), 
                                                            new KeyValuePair<string, string>("Content-Type", "application/json") });
                
                //TODO: Get these values from request or user management                
                const long contractVersion = (long)1.0;
                const Lace.Domain.Core.Requests.DeviceTypes fromDevice = Lace.Domain.Core.Requests.DeviceTypes.ApiClient;
                const string fromIpAddress = "127.0.0.1";
                const string osVersion = "";
                const Lace.Domain.Core.Requests.SystemType systemType = Lace.Domain.Core.Requests.SystemType.Api;


                var responses = ((Package) package).Execute(entryPoint, apiRequest.UserId, "",
                    "", Guid.NewGuid(), accountNumber, apiRequest.ContractId, contractVersion,
                    fromDevice, fromIpAddress, osVersion, systemType, apiRequest.RequestFields);

                integration.SendToBus(new MappedPackageResponseSentMessage(package.Id, apiRequest.UserId, apiRequest.ContractId, accountNumber, responses.AsJsonString()));

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
                dto.Id = Guid.NewGuid();

                var dProviders = Mapper.Map<IEnumerable<DataProviderDto>, IEnumerable<DataProviderOverride>>(dto.DataProviders);

                publisher.Publish(new CreatePackage(dto.Id, dto.Name, dto.Description, dto.CostOfSale,
                    dto.RecommendedSalePrice, dto.Notes, dto.Industries, dto.State, dto.Owner, DateTime.UtcNow, null,
                    dProviders));

                ////RabbitMQ
                var metaEntity = Mapper.Map(dto, new PackageMessage());
                var advancedBus = new TransactionBus(eBus);
                advancedBus.SendDynamic(metaEntity);

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

                ////RabbitMQ
                var metaEntity = Mapper.Map(dto, new PackageMessage());
                var advancedBus = new TransactionBus(eBus);
                advancedBus.SendDynamic(metaEntity);

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