using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using Api.Domain.Infrastructure.Dto;
using Api.Helpers.Validators;
using DataPlatform.Shared.Dtos;
using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using Nancy;
using Nancy.Json;
using Nancy.ModelBinding;
using Shared.BuildingBlocks.Api.ApiClients;
using Shared.BuildingBlocks.Api.Security;

namespace Api.Modules
{
    public class ActionModule : NancyModule // SecureModule
    {
        private static int _defaultJsonMaxLength;

        public ActionModule(IPackageBuilderApiClient packageBuilderApi, IUserManagementApiClient userManagementApi)
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
                try
                {
                    this.Info(() => "Api action started.");
                    var apiRequest = this.Bind<ApiRequestDto>();
                    var token = Context.Request.Headers.Authorization.Split(' ')[1];

                    new ApiRequestValidator(userManagementApi).AuthenticateRequest(token, apiRequest.UserId, apiRequest.CustomerClientId, apiRequest.ContractId);

                    this.Info(() => "Api request: ContractId {0} Api token:{1}".FormatWith(apiRequest.ContractId, token));
                    this.Info(() => "Api PB URI: {0}".FormatWith(ConfigurationManager.AppSettings["pbApi/config/baseUrl"]));

                    var responses = packageBuilderApi.Post("", "/Packages/Execute", apiRequest,
                        new[] { new KeyValuePair<string, string>("Authorization", "Token " + token), new KeyValuePair<string, string>("Content-Type", "application/json") });

                    this.Info(() => "Api responses: {0}".FormatWith(responses));
                    this.Info(() => "Api action completed.");

                    return responses;
                }
                catch (LightstoneAutoException execption)
                {
                    return Response.AsJson(new { error = execption.Message });
                }
                catch (TargetInvocationException targetInvocationException)
                {
                    return Response.AsJson(new { error = "Ensure all properties are populated" });
                }
            };
        }
    }
}