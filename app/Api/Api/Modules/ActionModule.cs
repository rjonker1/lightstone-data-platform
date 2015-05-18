using System;
using System.Collections.Generic;
using System.Configuration;
using Api.Domain.Infrastructure.Dto;
using DataPlatform.Shared.Dtos;
using DataPlatform.Shared.Helpers.Extensions;
using Nancy;
using Nancy.Json;
using Nancy.ModelBinding;
using Shared.BuildingBlocks.Api.ApiClients;
using Shared.BuildingBlocks.Api.Security;

namespace Api.Modules
{
    public class ActionModule : NancyModule  //SecureModule
    {
        private static int _defaultJsonMaxLength;

        public ActionModule(IPackageBuilderApiClient packageBuilderApi)
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

            Post["/action"] = parameters =>
            {
                this.Info(() => "Api action started.");
                var apiRequest = this.Bind<ApiRequestDto>();
                var token = Context.Request.Headers.Authorization.Split(' ')[1];
                this.Info(() => "Api request: ContractId {0} Api token:{1}".FormatWith(apiRequest.ContractId, token));
                this.Info(() => "Api PB URI: {0}".FormatWith(ConfigurationManager.AppSettings["pbApi/config/baseUrl"]));
                var responses = packageBuilderApi.Post("", "/Packages/Execute", apiRequest, new[] { new KeyValuePair<string, string>("Authorization", "Token " + token), new KeyValuePair<string, string>("Content-Type", "application/json"), });
                //var responses = packageBuilderApi.Get("", string.Format("/Packages/Execute/{0}/{1}/{2}/{3}", apiRequest.PackageId, apiRequest.UserId, apiRequest.SearchTerm, Guid.NewGuid()), null, new[] { new KeyValuePair<string, string>("Authorization", "Token " + token) });
                this.Info(() => "Api responses: {0}".FormatWith(responses));
                this.Info(() => "Api action completed.");
                return responses;
            };
        }
    }
}