using System;
using System.Linq;
using Api.Domain.Infrastructure.Dto;
using Api.Domain.Infrastructure.Extensions;
using Api.Domain.Infrastructure.Transactions;
using Billing.Api.Connector;
using DataPlatform.Shared.Dtos;
using Lace.Domain.Infrastructure.Core.Contracts;
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
            ICreateBillingTransaction billingTransaction)
        {
            Get["/"] = parameters =>
            {
                var token = Context.AuthorizationHeaderToken();
                var metaData = packageBuilderApi.Get<ApiMetaData>(token, "getUserMetaData");

                return Response.AsJson(metaData);
            };

            Post["/action/SearchUsingLicensePlateNumber"] = parameters =>
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

                var jsonPackage = packageBuilderApi.Get(token, "Packages/Package/" + packageDetails.PackageId);
                var package = jsonPackage.ToPackage();

                if (package == null)
                    throw new Exception("Package could not be resolved");
                
                var request = package.ToLicensePlateSearchRequest(userId, apiRequest.Username,
                    apiRequest.SearchTerm, apiRequest.Username);

                var responses = entryPoint.GetResponsesFromLace(request);

                billingTransaction.CreateBillingTransactionForPackage(package, userId);
                if (!billingTransaction.BillingTransactionCreated)
                    throw new Exception("Package could not be processed");

                return Response.AsJson(responses.First().Response);
            };
        }
    }
}