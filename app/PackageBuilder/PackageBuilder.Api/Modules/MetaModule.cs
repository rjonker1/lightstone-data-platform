using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataPlatform.Shared.Dtos;
using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Domain.Metadata.Entrypoint;
using Lace.Shared.Extensions;
using Lim.Domain.Messaging.Messages;
using Lim.Domain.Messaging.Publishing;
using Nancy;
using Nancy.ModelBinding;
using PackageBuilder.Api.Helpers;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Domain.Dtos;
using PackageBuilder.Domain.Entities.Contracts.DataProviders.Write;
using Shared.BuildingBlocks.Api.ApiClients;
using Package = PackageBuilder.Domain.Entities.Packages.Write.Package;

namespace PackageBuilder.Api.Modules
{
    public class MetaModule : NancyModule
    {
        public MetaModule(INEventStoreRepository<Package> writeRepo, IUserManagementApiClient userManagementApi, IPublishIntegrationMessages integration, CurrentContext nancyContext)
        {
            Post["/Packages/Execute/Meta"] = parameters =>
            {
                var apiRequest = this.Bind<ApiRequestDto>();

                var package = writeRepo.GetById(apiRequest.PackageId);

                if (package == null)
                {
                    this.Error(() => "Package not found:".FormatWith(apiRequest.PackageId));
                    throw new LightstoneAutoException("Package could not be found");
                }

                //var token = Context.Request.Headers.Authorization.Split(' ')[1];
                //var resource = string.Format("CustomerClient/{0}", apiRequest.CustomerClientId);
                //var accountNumber = userManagementApi.Get("", resource, "", new[]
                //{
                //    new KeyValuePair<string, string>("Authorization", "Token " + token),
                //    new KeyValuePair<string, string>("Content-Type", "application/json")
                //});

                const string accountNumber = "META";

                const long contractVersion = (long)1.0;
                const Lace.Domain.Core.Requests.DeviceTypes fromDevice = Lace.Domain.Core.Requests.DeviceTypes.ApiClient;
                const string fromIpAddress = "127.0.0.1";
                const string osVersion = "";
                const Lace.Domain.Core.Requests.SystemType systemType = Lace.Domain.Core.Requests.SystemType.Api;

                var requestId = Guid.NewGuid();
                var responses = ((Package)package).ExecuteMeta(new MetadataEntryPointService(), apiRequest.UserId, nancyContext.Context.CurrentUser.UserName,
                    nancyContext.Context.CurrentUser.UserName, requestId, accountNumber, apiRequest.ContractId, contractVersion,
                    fromDevice, fromIpAddress, osVersion, systemType, apiRequest.RequestFields);

                // Filter responses for cleaner api payload
                var filteredResponse = Mapper.Map<IEnumerable<IDataProvider>, IEnumerable<ResponseDataProviderDto>>(responses);

                integration.SendToBus(new PackageResponseMessage(package.Id, apiRequest.UserId, apiRequest.ContractId, accountNumber,
                    responses.Any() ? responses.AsJsonString() : string.Empty, requestId, nancyContext.Context != null ? nancyContext.Context.CurrentUser.UserName : "unavailable"));

                return filteredResponse;
            };
        }
    }
}