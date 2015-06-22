﻿using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using Api.Helpers.Validators;
using DataPlatform.Shared.Dtos;
using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using Nancy;
using Nancy.ModelBinding;
using Shared.BuildingBlocks.Api.ApiClients;

namespace Api.Modules
{
    public class MetaModule : NancyModule
    {
        public MetaModule(IPackageBuilderApiClient packageBuilderApi, IUserManagementApiClient userManagementApi)
        {
            Post["/action/meta"] = parameters =>
            {
                try
                {
                    this.Info(() => "Api action meta started.");
                    var apiRequest = this.Bind<ApiRequestDto>();
                    var token = Context.Request.Headers.Authorization.Split(' ')[1];

                    //new ApiRequestValidator(userManagementApi)
                    //    .AuthenticateRequest(token, apiRequest.UserId, apiRequest.CustomerClientId, apiRequest.ContractId, apiRequest.PackageId);

                    this.Info(() => "Api request: ContractId {0} Api token:{1}".FormatWith(apiRequest.ContractId, token));
                    this.Info(() => "Api PB URI: {0}".FormatWith(ConfigurationManager.AppSettings["pbApi/config/baseUrl"]));

                    var responses = packageBuilderApi.Post("", "/Packages/Execute/Meta", apiRequest, new[] { new KeyValuePair<string, string>("Authorization", "Token " + token), new KeyValuePair<string, string>("Content-Type", "application/json"), });

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