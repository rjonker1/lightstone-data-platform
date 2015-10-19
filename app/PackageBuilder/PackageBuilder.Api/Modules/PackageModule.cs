using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using DataPlatform.Shared.Dtos;
using DataPlatform.Shared.Enums;
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
using Nancy.Security;
using PackageBuilder.Api.Helpers.Extensions;
using PackageBuilder.Api.Routes;
using PackageBuilder.Core.Helpers;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.CommandHandlers;
using PackageBuilder.Domain.Dtos;
using PackageBuilder.Domain.Dtos.Write;
using PackageBuilder.Domain.Entities.Contracts.DataProviders.Write;
using PackageBuilder.Domain.Entities.Contracts.Packages.Write;
using PackageBuilder.Domain.Entities.DataProviders.Write;
using PackageBuilder.Domain.Entities.Enums.States;
using PackageBuilder.Domain.Entities.Industries.Read;
using PackageBuilder.Domain.Entities.Packages.Commands;
using PackageBuilder.Domain.Entities.States.Read;
using Shared.BuildingBlocks.Api.ApiClients;
using Shared.BuildingBlocks.Api.Security;
using DataProviderDto = PackageBuilder.Domain.Dtos.Write.DataProviderDto;
using Package = PackageBuilder.Domain.Entities.Packages.Write.Package;

namespace PackageBuilder.Api.Modules
{
    public class PackageModule : SecureModule
    {
        public PackageModule(IPublishStorableCommands publisher,
            IRepository<Domain.Entities.Packages.Read.Package> readRepo,
            INEventStoreRepository<Package> writeRepo, IRepository<State> stateRepo, IEntryPoint entryPoint, IAdvancedBus eBus, IUserManagementApiClient userManagementApi, IPublishIntegrationMessages integration)
        {
           
            Get[PackageBuilderApi.PackageRoutes.RequestIndex.ApiRoute] = _ =>
            {
                return _.showAll
                    ? Response.AsJson(
                        from p1 in readRepo
                        where p1.Version == (from p2 in readRepo where p2.PackageId == p1.PackageId && !p2.IsDeleted select p2.Version).Max()
                        select p1)
                    : Response.AsJson(readRepo.Where(x => !x.IsDeleted));
            };

            Get[PackageBuilderApi.PackageRoutes.RequestLookup.ApiRoute] = parameters =>
            {
                var filter = (string)Context.Request.Query["q_word[]"].Value;
                var pageIndex = 0;
                var pageSize = 0;
                int.TryParse(Context.Request.Query["page_num"].Value, out pageIndex);
                int.TryParse(Context.Request.Query["per_page"].Value, out pageSize);

                //string filter = (parameters.filter + "").Trim().ToLower();
                Expression<Func<Domain.Entities.Packages.Read.Package, bool>> predicate = x => !x.IsDeleted && (x.Name + "").Trim().ToLower().StartsWith(filter);
                predicate = package => true;

                //var publishedPackages = from p in readRepo
                //                        where p.Id == (from pp in readRepo
                //                                       where p.State.Name == StateName.Published
                //                                       orderby pp.Version descending
                //                                       select pp.Id).FirstOrDefault()
                //                        select p;

                var industries = Enumerable.Empty<Guid>();
                if (parameters.industryIds.Value != null)
                {
                    var industryString = (string)parameters.industryIds.Value;
                    industries = industryString.Split(',').Select(x => new Guid(x));
                }

                //var packagesTest = readRepo.Where(x => x.State.Name == StateName.Published).OrderByDescending(d => d.Version);
                var packagesTest = readRepo.Where(x => x.State.Name == StateName.Published && x.Industries.Any(ind => industries.Contains(ind.Id))).OrderByDescending(d => d.Version);

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
                                                pageIndex - 1, pageSize, predicate);
                return Response.AsJson(
                        new
                        {
                            result = packages,
                            cnt_whole = packages.RecordsFiltered
                        });
            };

            Get[PackageBuilderApi.PackageRoutes.RequestUpdate.ApiRoute] = parameters => Response.AsJson(
                new
                {
                    Response = new[] { Mapper.Map<IPackage, PackageDto>(writeRepo.GetById(parameters.id)) }
                });


            Post[PackageBuilderApi.PackageRoutes.Execute.ApiRoute] = parameters =>
            {
                var apiRequest = this.Bind<ApiRequestDto>();
                this.Info(() => "Package Execute Initialized for {0}, TimeStamp: {1}".FormatWith(apiRequest.RequestId, DateTime.UtcNow));

                this.Info(() => "Package Read Initialized, TimeStamp: {0}".FormatWith(DateTime.UtcNow));
                var package = writeRepo.GetById(apiRequest.PackageId, true);
                this.Info(() => "Package Read Completed, TimeStamp: {0}".FormatWith(DateTime.UtcNow));

                if (package == null)
                {
                    this.Error(() => "Package not found:".FormatWith(apiRequest.PackageId));
                    throw new LightstoneAutoException("Package could not be found");
                }

                this.Info(() => "PackageBuilder Auth to UserManagement Initialized for {0}, TimeStamp: {1}".FormatWith(apiRequest.RequestId, DateTime.UtcNow));
                var token = Context.Request.Headers.Authorization.Split(' ')[1];
                var accountNumber = userManagementApi.Get(token, "/CustomerClient/{id}", new[] { new KeyValuePair<string, string>("id", apiRequest.CustomerClientId.ToString()) }, null);

                this.Info(() => "PackageBuilder Auth to UserManagement Completed for {0}, TimeStamp: {1}".FormatWith(apiRequest.RequestId, DateTime.UtcNow));

                var responses = ((Package)package).Execute(entryPoint, apiRequest.UserId, Context.CurrentUser.UserName,
                    Context.CurrentUser.UserName, apiRequest.RequestId, accountNumber, apiRequest.ContractId, apiRequest.ContractVersion,
                    apiRequest.DeviceType, apiRequest.FromIpAddress, "", apiRequest.SystemType, apiRequest.RequestFields, (double)package.CostOfSale, (double)package.RecommendedSalePrice, apiRequest.HasConsent);

                // Filter responses for cleaner api payload
                this.Info(() => "Package Response Filter Cleanup Initialized for {0}, TimeStamp: {1}".FormatWith(apiRequest.RequestId, DateTime.UtcNow));
                var filteredResponse = new List<IProvideResponseDataProvider>
                {
                    new ResponseMeta(apiRequest.RequestId, responses.ResponseState())
                };

                filteredResponse.AddRange(Mapper.Map<IEnumerable<IDataProvider>, IEnumerable<IProvideResponseDataProvider>>(responses));
                this.Info(() => "Package Response Filter Cleanup Completed for {0}, TimeStamp: {1}".FormatWith(apiRequest.RequestId, DateTime.UtcNow));

                integration.SendToBus(new PackageResponseMessage(package.Id, apiRequest.UserId, apiRequest.ContractId, accountNumber,
                    filteredResponse.Any() ? filteredResponse.AsJsonString() : string.Empty, apiRequest.RequestId, Context != null ? Context.CurrentUser.UserName : "unavailable"));

                this.Info(() => "Package Execute Completed for {0}, TimeStamp: {1}".FormatWith(apiRequest.RequestId, DateTime.UtcNow));

                return filteredResponse;
            };

            Post[PackageBuilderApi.PackageRoutes.CommitRequest.ApiRoute] = _ =>
            {
                var apiRequest = this.Bind<CommitRequestDto>();

                if (apiRequest.RequestId == Guid.Empty) return Response.AsJson(new { data = "Please supply a valid RequestId" });

                
                this.Info(() => "Package Execute Initialized for {0}, TimeStamp: {1}".FormatWith(apiRequest.RequestId, DateTime.UtcNow));

                this.Info(() => "Package Read Initialized, TimeStamp: {0}".FormatWith(DateTime.UtcNow));
                var package = writeRepo.GetById(apiRequest.PackageId, true);
                this.Info(() => "Package Read Completed, TimeStamp: {0}".FormatWith(DateTime.UtcNow));

                if (package == null)
                {
                    this.Error(() => "Package not found:".FormatWith(apiRequest.PackageId));
                    throw new LightstoneAutoException("Package could not be found");
                }

                this.Info(() => "PackageBuilder Auth to UserManagement Initialized for {0}, TimeStamp: {1}".FormatWith(apiRequest.RequestId, DateTime.UtcNow));
                var token = Context.Request.Headers.Authorization.Split(' ')[1];
                var accountNumber = userManagementApi.Get(token, "/CustomerClient/{id}", new[] { new KeyValuePair<string, string>("id", apiRequest.CustomerClientId.ToString()) }, null);

                this.Info(() => "PackageBuilder Auth to UserManagement Completed for {0}, TimeStamp: {1}".FormatWith(apiRequest.RequestId, DateTime.UtcNow));

                var responses = ((Package)package).ExecuteWithCarId(entryPoint, apiRequest.UserId, Context.CurrentUser.UserName,
                    Context.CurrentUser.UserName, apiRequest.RequestId, accountNumber, apiRequest.ContractId, apiRequest.ContractVersion,
                    apiRequest.DeviceType, apiRequest.FromIpAddress, "", apiRequest.SystemType, apiRequest.RequestFields, (double)package.CostOfSale, (double)package.RecommendedSalePrice, apiRequest.HasConsent);

                // Filter responses for cleaner api payload
                this.Info(() => "Package Response Filter Cleanup Initialized for {0}, TimeStamp: {1}".FormatWith(apiRequest.RequestId, DateTime.UtcNow));
                var filteredResponse = new List<IProvideResponseDataProvider>
                {
                    new ResponseMeta(apiRequest.RequestId, responses.ResponseState())
                };

                filteredResponse.AddRange(Mapper.Map<IEnumerable<IDataProvider>, IEnumerable<IProvideResponseDataProvider>>(responses));
                this.Info(() => "Package Response Filter Cleanup Completed for {0}, TimeStamp: {1}".FormatWith(apiRequest.RequestId, DateTime.UtcNow));

                integration.SendToBus(new PackageResponseMessage(package.Id, apiRequest.UserId, apiRequest.ContractId, accountNumber,
                    filteredResponse.Any() ? filteredResponse.AsJsonString() : string.Empty, apiRequest.RequestId, Context != null ? Context.CurrentUser.UserName : "unavailable"));

                this.Info(() => "Package Execute Completed for {0}, TimeStamp: {1}".FormatWith(apiRequest.RequestId, DateTime.UtcNow));

                return filteredResponse;
            };

            Post[PackageBuilderApi.PackageRoutes.ProcessCreate.ApiRoute] = parameters =>
            {
                var dto = this.Bind<PackageDto>();
                dto.Id = dto.Id == new Guid() ? Guid.NewGuid() : dto.Id; // Required for acceptance tests where we specify the Id

                var dProviders = Mapper.Map<IEnumerable<DataProviderDto>, IEnumerable<DataProviderOverride>>(dto.DataProviders);

                publisher.Publish(new CreatePackage(dto.Id, dto.Name, dto.Description, dto.CostOfSale,
                    dto.RecommendedSalePrice, dto.Notes, dto.PackageEventType, Mapper.Map<PackageDto, IEnumerable<Industry>>(dto), dto.State, dto.Owner, DateTime.UtcNow, null,
                    dProviders));

                ////RabbitMQ
                var metaEntity = Mapper.Map(dto, new PackageMessage());
                var advancedBus = new TransactionBus(eBus);
                advancedBus.SendDynamic(metaEntity);

                return Response.AsJson(new { msg = "Success" });
            };

            Put[PackageBuilderApi.PackageRoutes.ProcessUpdate.ApiRoute] = parameters =>
            {
                var dto = this.Bind<PackageDto>();
                var dProviders =
                    Mapper.Map<IEnumerable<DataProviderDto>, IEnumerable<DataProviderOverride>>(dto.DataProviders);

                publisher.Publish(new UpdatePackage(parameters.id, dto.Name, dto.Description, dto.CostOfSale,
                    dto.RecommendedSalePrice, dto.Notes, dto.PackageEventType, Mapper.Map<PackageDto, IEnumerable<Industry>>(dto), dto.State, dto.Version, dto.Owner,
                    dto.CreatedDate, DateTime.UtcNow, dProviders));

                ////RabbitMQ
                var metaEntity = Mapper.Map(dto, new PackageMessage());
                var advancedBus = new TransactionBus(eBus);
                advancedBus.SendDynamic(metaEntity);

                return Response.AsJson(new { msg = "Success, " + parameters.id + " edited" });
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
                    packageToClone.PackageEventType,
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

            Delete[PackageBuilderApi.PackageRoutes.ProcessDelete.ApiRoute] = parameters =>
            {
                this.RequiresAnyClaim(new[] { RoleType.Admin.ToString(), RoleType.ProductManager.ToString(), RoleType.Support.ToString() });

                publisher.Publish(new DeletePackage(new Guid(parameters.id)));

                return Response.AsJson(new { msg = "Success, " + parameters.id + " deleted" });
            };
        }
    }
}