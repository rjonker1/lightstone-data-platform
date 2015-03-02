using System;
using System.Linq;
using Api.Domain.Infrastructure.Billing;
using Api.Domain.Infrastructure.Dto;
using Api.Domain.Infrastructure.Extensions;
using Billing.Api.Connector;
using DataPlatform.Shared.Dtos;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Shared.Monitoring.Messages.Commands;
using Nancy;
using Nancy.ModelBinding;
using Shared.BuildingBlocks.Api.ApiClients;
using Shared.BuildingBlocks.Api.Security;

namespace Api.Modules
{
    public class ActionModule : SecureModule
    {
        public ActionModule(IPackageBuilderApiClient packageBuilderApi, IEntryPoint entryPoint,
            IConnectToBilling billingConnector, IUserManagementApiClient userManagementApi,
            ICreateBillingTransaction billingTransaction, ICreateBillingResponse billingResponse)
        {
            Get["/"] = parameters =>
            {
                var token = Context.AuthorizationHeaderToken();
                var metaData = packageBuilderApi.Get<ApiMetaData>(token, "getUserMetaData");

                return Response.AsJson(metaData);
            };

            Post["/action/LicensePlateNumberSearch"] = parameters =>
            {
                var token = Context.AuthorizationHeaderToken();

                if (string.IsNullOrEmpty(token))
                    throw new Exception("Invalid user credentials");

                var apiRequest = this.Bind<ApiRequestDto>();
                apiRequest.Username = Context.CurrentUser.UserName;
                if (!apiRequest.IsValid())
                    throw new Exception("Invalid search request");

                //var packageDetails = userManagementApi.Post<ContractResponse>(token, "/Contracts/GetPackage", new {apiRequest.ContractId});
                var userId = new Guid(token);
                var packageDetails = userManagementApi.Post<ContractResponse>(token, "/Packages/GetPackage", new { userId });

                if (packageDetails == null)
                    throw new Exception("Could not get package for contract");

                var jsonPackage = packageBuilderApi.Get(token, "Packages/DataProvider/" + packageDetails.PackageId);
                var package = jsonPackage.ToPackage();

                if (package == null)
                    throw new Exception("Package for data provider could not be resolved");

                var requestId = Guid.NewGuid(); //for billing!!

                billingTransaction.CreateBillingTransactionForPackage(package, userId, requestId);
                if (!billingTransaction.BillingCreated) 
                    throw new Exception("Package could not be processed");

                var request = package.ToLicensePlateSearchRequest(userId, apiRequest.Username,
                    apiRequest.SearchTerm, apiRequest.Username, requestId);

                var responses = entryPoint.GetResponsesFromLace(request);

                if(!responses.Any())
                    throw new Exception("No response for package");

                billingResponse.CreateBillingResponseForPackage(package, userId, requestId);

                if (!billingResponse.BillingCreated)
                    throw new Exception("Response for request could not be processed");

                return Response.AsJson(responses.First().Response);
            };
        }
    }
}