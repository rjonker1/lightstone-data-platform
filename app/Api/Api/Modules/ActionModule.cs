﻿using System;
using System.Configuration;
using System.Reflection;
using Api.Domain.Core.Messages;
using Api.Domain.Infrastructure.Bus;
using Api.Domain.Infrastructure.Extensions;
using Api.Helpers.Validators;
using DataPlatform.Shared.Dtos;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using Nancy;
using Nancy.ModelBinding;
using Shared.BuildingBlocks.Api.ApiClients;
using Shared.BuildingBlocks.Api.Security;

namespace Api.Modules
{
    public class ActionModule : SecureModule
    {
        public ActionModule(IPackageBuilderApiClient packageBuilderApi, IAuthenticateApi authenticator,IDispatchMessagesToBus<RequestMetadataMessage> dispatcher)
        {
            Get["/"] = parameters =>
            {
                var token = Context.AuthorizationHeaderToken();
                var metaData = packageBuilderApi.Get<ApiMetaData>(token, "getUserMetaData");
                return Response.AsJson(metaData);
            };

            Post["/action", true] = async (parameters, cancellationToken) =>
            {
                if (Convert.ToBoolean(ConfigurationManager.AppSettings["maintenanceMode"]))
                    return Response.AsJson(new {data = "Service unavailable - Maintenance in progress"}, HttpStatusCode.ServiceUnavailable);

                try
                {
                    this.Info(() => "Api action started. TimeStamp: {0}".FormatWith(DateTime.UtcNow));
                    var apiRequest = this.Bind<ApiRequestDto>();
                    this.Info(() => "Api action started. RequestId: {0} TimeStamp: {1}".FormatWith(apiRequest.RequestId, DateTime.UtcNow));
                    var token = Context.Request.Headers.Authorization.Split(' ')[1];

                    this.Info(() => "AuthenticateNewRequest started. RequestId: {0} TimeStamp: {1}".FormatWith(apiRequest.RequestId, DateTime.UtcNow));
                    apiRequest = await authenticator.AuthenticateNewRequest(token, cancellationToken, apiRequest);
                    this.Info(() => "AuthenticateNewRequest finished. RequestId: {0} TimeStamp: {1}".FormatWith(apiRequest.RequestId, DateTime.UtcNow));

                    this.Info(() => "Api request: ContractId {0} Api token:{1}".FormatWith(apiRequest.ContractId, token));
                    this.Info(() => "Api PB URI: {0}".FormatWith(ConfigurationManager.AppSettings["pbApi/config/baseUrl"]));

                    Context.Report(dispatcher, apiRequest.RequestId);

                    this.Info(() => "Api to PackageBuilder Execute Initialized. RequestId: {0} TimeStamp: {1}".FormatWith(apiRequest.RequestId, DateTime.UtcNow));
                    var responses = await packageBuilderApi.PostAsync(token, cancellationToken, "/Packages/Execute", null, apiRequest);
                    this.Info(() => "Api to PackageBuilder Execute Completed. RequestId: {0} TimeStamp: {1}".FormatWith(apiRequest.RequestId, DateTime.UtcNow));

                    this.Info(() => "Api responses: {0}".FormatWith(responses));
                    this.Info(() => "Api action completed. RequestId: {0} TimeStamp: {1}".FormatWith(apiRequest.RequestId, DateTime.UtcNow));

                    return responses;
                }
                catch (LightstoneAutoException ex)
                {
                    return Response.AsJson(new {error = ex.Message});
                }
                catch (TargetInvocationException)
                {
                    return Response.AsJson(new {error = "Ensure all properties are populated"});
                }
            };

            Post["/action/requestId/{requestId}/userstate/{stateId}", true] = async (parameters, cancellationToken) =>
            {
                if (Convert.ToBoolean(ConfigurationManager.AppSettings["maintenanceMode"]))
                    return Response.AsJson(new {data = "Service unavailable - Maintenance in progress"}, HttpStatusCode.ServiceUnavailable);
                try
                {
                    this.Info(() => "Api Commit Request started. TimeStamp: {0}".FormatWith(DateTime.UtcNow));
                    var apiRequest = this.Bind<ApiCommitRequestDto>();
                    var token = Context.Request.Headers.Authorization.Split(' ')[1];

                    apiRequest = await authenticator.AuthenticateExistingRequest(token, cancellationToken, apiRequest);

                    this.Info(() => "Api request: ContractId {0} Api token: {1}".FormatWith(apiRequest.ContractId, token));
                    this.Info(() => "Api PB URI: {0}".FormatWith(ConfigurationManager.AppSettings["pbApi/config/baseUrl"]));

                    apiRequest.AddStateForRequest(Guid.Parse(parameters.requestId.ToString()), ((ApiCommitRequestUserState) int.Parse(parameters.stateId)));
                    Context.Report(dispatcher, apiRequest.RequestId);

                    this.Info(() => "Api to PackageBuilder Commit Request Initialized. TimeStamp: {0}".FormatWith(DateTime.UtcNow));
                    var responses = await packageBuilderApi.PostAsync(token, cancellationToken, "/Packages/CommitRequest", null, apiRequest);
                    this.Info(() => "Api to PackageBuilder Commit Request Completed. TimeStamp: {0}".FormatWith(DateTime.UtcNow));

                    this.Info(() => "Api responses: {0}".FormatWith(responses));
                    this.Info(() => "Api action completed. TimeStamp: {0}".FormatWith(DateTime.UtcNow));

                    return responses;
                }
                catch (LightstoneAutoException ex)
                {
                    return Response.AsJson(new {error = ex.Message});
                }
                catch (TargetInvocationException)
                {
                    return Response.AsJson(new {error = "Ensure all properties are populated"});
                }
            };
        }
    }
}