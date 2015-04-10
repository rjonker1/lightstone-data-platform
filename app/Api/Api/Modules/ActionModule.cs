using System;
using System.Collections.Generic;
using Api.Domain.Infrastructure.Dto;
using DataPlatform.Shared.Dtos;
using DataPlatform.Shared.Helpers.Extensions;
using Nancy;
using Nancy.Authentication.Token;
using Nancy.Helpers;
using Nancy.Json;
using Nancy.ModelBinding;
using Shared.BuildingBlocks.Api.ApiClients;
using Shared.BuildingBlocks.Api.Security;

namespace Api.Modules
{
    public class ActionModule : SecureModule
    {
        private static int _defaultJsonMaxLength;

        public ActionModule(IPackageBuilderApiClient packageBuilderApi, IUserManagementApiClient userManagementApi, ITokenizer tokenizer)
        {
            if (_defaultJsonMaxLength == 0)
                _defaultJsonMaxLength = JsonSettings.MaxJsonLength;

            //Hackeroonie - Required, due to complex model structures (Nancy default restriction length [102400])
            JsonSettings.MaxJsonLength = Int32.MaxValue;

            Get["/"] = parameters =>
            {
                var token = Context.AuthorizationHeaderToken();
                var metaData = packageBuilderApi.Get<ApiMetaData>(token, "getUserMetaData");

                return Response.AsJson(metaData);
            };

            //TODO: Refactor!!!! This looks crap
            Post["/action/LicensePlateNumberSearch"] = parameters =>
            {
                //var token = Context.AuthorizationHeaderToken();

                //if (string.IsNullOrEmpty(token))
                //    throw new Exception("Invalid user credentials");

                var apiRequest = this.Bind<ApiRequestDto>();
                apiRequest.Username = Context.CurrentUser.UserName;
                //if (!apiRequest.IsValid())
                //    throw new Exception("Invalid search request");

                var token = Context.Request.Headers.Authorization.Split(' ')[1];
                //var userIdentity = tokenizer.Detokenize(token, Context, new DefaultUserIdentityResolver());


                //var packageDetails = userManagementApi.Post<ContractResponse>("", "/Packages/GetPackage", new { apiRequest.UserId }, new[] { new KeyValuePair<string, string>("Authorization", "Token " + token) });

                //if (packageDetails == null)
                //    throw new Exception("Could not get package for contract");

                //var responses = packageBuilderApi.Get("", string.Format("/Packages/Execute/{0}/{1}/{2}/{3}", packageDetails.PackageId, apiRequest.UserId, apiRequest.SearchTerm, Guid.NewGuid()), null, new[] { new KeyValuePair<string, string>("Authorization", "Token " + token) });
                var responses = packageBuilderApi.Get("", string.Format("/Packages/Execute/{0}/{1}/{2}/{3}", apiRequest.PackageId, apiRequest.UserId, apiRequest.SearchTerm, Guid.NewGuid()), null, new[] { new KeyValuePair<string, string>("Authorization", "Token " + token) });
                //var package = jsonPackage.ToPackage();

                //if (package == null)
                //    throw new Exception("Package for data provider could not be resolved");

                //var requestId = Guid.NewGuid();

                //var request = package.ToLicensePlateSearchRequest(userId, apiRequest.Username, apiRequest.SearchTerm, apiRequest.Username, requestId);
                //var request = package.FormLaceRequest(userId, apiRequest.Username, apiRequest.SearchTerm, apiRequest.Username, requestId);

                //var responses = entryPoint.GetResponsesFromLace(request);
                //var test = package.MapLaceResponses(responses);
                //var ivid = ((IProvideDataFromIvid) responses.First());
                //var test1 = package.MapLaceResponses(new List<IPointToLaceProvider>() { ivid });
                //if (!responses.Any())
                //    throw new Exception("No response for package");



                //billingTransaction.CreateBillingTransactionForPackage(package, userId, requestId);
                //if (!billingTransaction.BillingCreated)
                //    throw new Exception("Package could not be processed");

                return responses;
            };

            ////TODO: Refactor!!!! This looks crap too
            //Post["/action/PropertySearch"] = parameters =>
            //{
            //    //var token = Context.AuthorizationHeaderToken();

            //    //if (string.IsNullOrEmpty(token))
            //    //    throw new Exception("Invalid user credentials");

            //    //var apiRequest = this.Bind<ApiPropertyRequest>();
            //    //apiRequest.Username = Context.CurrentUser.UserName;

            //    //if (!apiRequest.IsValid())
            //    //    throw new Exception("Invalid search request");

            //    ////TODo: Need to uncomment. Only commented out because mutliple packages per user has not bee sorted out yet
            //    //var userId = new Guid(token);
            //    ////var packageDetails = userManagementApi.Post<ContractResponse>(token, "/Packages/GetPackage",
            //    ////    new {userId});

            //    ////if (packageDetails == null)
            //    ////    throw new Exception("Could not get package for contract");

            //    ////TODO: Need to remove hardcoded package id - Just for testing and until multiple packages per user is sorted out
            //    //var packageid = new Guid("936867FA-D9F4-4E9C-9D62-6B7B48FAC974");

            //    ////var jsonPackage = packageBuilderApi.Get(token, "Packages/DataProvider/ForPropertySearch/" + packageDetails.PackageId);
            //    //var jsonPackage = packageBuilderApi.Get(token, "Packages/DataProvider/ForPropertySearch/" + packageid);
            //    //var package = jsonPackage.ToPackage();

            //    //if (package == null)
            //    //    throw new Exception("Package for data provider could not be resolved");

            //    //var requestId = Guid.NewGuid();


            //    ////TODO: Hard coded user id to get working - NEED TO REMOVE!!!!
            //    //var request = package.ToPropertySearchRequest(new Guid("5a7222e1-ee65-433b-b673-827319e89cbb"),
            //    //    apiRequest.IdNumber, apiRequest.MaxRowsToReturn,
            //    //    apiRequest.TrackingNumber, requestId, "ACC00000", 1, apiRequest.ContractId, DeviceTypes.Desktop,
            //    //    "0.0.0.0", string.Empty, SystemType.Api);

            //    //var responses = entryPoint.GetResponsesFromLace(new[] {request});

            //    //if (!responses.Any())
            //    //    throw new Exception("No response for package");

            //    ////billingTransaction.CreateBillingTransactionForPackage(package, userId, requestId);
            //    ////if (!billingTransaction.BillingCreated)
            //    ////    throw new Exception("Package could not be processed");

            //    //return Response.AsJson(responses);
            //};
        }
    }
}