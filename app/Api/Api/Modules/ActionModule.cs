using System;
using System.Collections.Generic;
using Api.Domain.Infrastructure.Dto;
using DataPlatform.Shared.Dtos;
using Nancy;
using Nancy.Json;
using Nancy.ModelBinding;
using Shared.BuildingBlocks.Api.ApiClients;
using Shared.BuildingBlocks.Api.Security;

namespace Api.Modules
{
    public class ActionModule : SecureModule
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

            Post["/action/LicensePlateNumberSearch"] = parameters =>
            {
                var apiRequest = this.Bind<ApiRequestDto>();
                var token = Context.Request.Headers.Authorization.Split(' ')[1];
                var responses = packageBuilderApi.Post("", "/Packages/Execute", apiRequest, new[] { new KeyValuePair<string, string>("Authorization", "Token " + token), new KeyValuePair<string, string>("Content-Type", "application/json"), });
                //var responses = packageBuilderApi.Get("", string.Format("/Packages/Execute/{0}/{1}/{2}/{3}", apiRequest.PackageId, apiRequest.UserId, apiRequest.SearchTerm, Guid.NewGuid()), null, new[] { new KeyValuePair<string, string>("Authorization", "Token " + token) });
                return responses;
            };
        }
    }
}