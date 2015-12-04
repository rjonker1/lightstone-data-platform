using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataPlatform.Shared.Dtos;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using Lace.Domain.Metadata.Entrypoint;
using Lace.Shared.Extensions;
using Lim.Domain.Messaging.Messages;
using Lim.Domain.Messaging.Publishing;
using Nancy;
using Nancy.ModelBinding;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Domain.Dtos;
using PackageBuilder.Domain.Entities.Contracts.DataProviders.Write;
using PackageBuilder.Domain.Entities.Requests;
using PackageBuilder.Domain.Entities.Requests.RequestTypes;
using PackageBuilder.Infrastructure.NEventStore;
using Shared.BuildingBlocks.Api.Security;
using Shared.Logging;
using Package = PackageBuilder.Domain.Entities.Packages.Write.Package;

namespace PackageBuilder.Api.Modules
{
    public class MetaModule : SecureModule
    {
        public MetaModule(INEventStoreRepository<Package> writeRepo, IPublishIntegrationMessages integration)
        {
            Post["/Packages/Execute/Meta", true] = async(parameters, ct) =>
            {
                var apiRequest = this.Bind<ApiRequestDto>();

                var package = await writeRepo.GetById(apiRequest.PackageId);

                if (package == null)
                {
                    this.Error(() => "Package meta data not found for id {0}".FormatWith(apiRequest.PackageId), SystemName.PackageBuilder);
                    throw new LightstoneAutoException("Package could not be found");
                }

                const long contractVersion = (long)1.0;
                const DeviceTypes fromDevice = DeviceTypes.ApiClient;
                const string fromIpAddress = "127.0.0.1";
                const string osVersion = "";
                const SystemType systemType = SystemType.Api;

                var requestId = Guid.NewGuid();
                var contractId = new Guid();
                var userId = new Guid();
                const string accountNumber = "META";

                var responses = ((Package)package).Execute(new MetadataEntryPointService(), new ExecuteLaceRequest(userId, Context.CurrentUser.UserName,
                    Context.CurrentUser.UserName, requestId, accountNumber, contractId, contractVersion,systemType, apiRequest.RequestFields, (double)package.CostOfSale, (double)package.RecommendedSalePrice, true,"0118926242",new RequestTypeBuilderFactory()));

                // Filter responses for cleaner api payload
                var filteredResponse = Mapper.Map<IEnumerable<IDataProvider>, IEnumerable<ResponseDataProviderDto>>(responses);

                integration.SendToBus(new PackageResponseMessage(package.Id, apiRequest.UserId, apiRequest.ContractId, accountNumber,
                    responses.Any() ? responses.AsJsonString() : string.Empty, requestId, Context != null ? Context.CurrentUser.UserName : "unavailable"));

                return Response.AsJson(filteredResponse);
            };
        }
    }
}