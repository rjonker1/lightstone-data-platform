using System;
using System.Configuration;
using System.Reflection;
using Api.Domain.Infrastructure.Bus;
using Api.Domain.Infrastructure.Extensions;
using Api.Domain.Infrastructure.Messages;
using Api.Helpers.Validators;
using DataPlatform.Shared.Dtos;
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
        public ActionModule(IPackageBuilderApiClient packageBuilderApi, IUserManagementApiClient userManagementApi, IDispatchMessagesToBus<RequestReportMessage> dispatcher)
        {
            Get["/"] = parameters =>
            {
                var token = Context.AuthorizationHeaderToken();
                var metaData = packageBuilderApi.Get<ApiMetaData>(token, "getUserMetaData");
                return Response.AsJson(metaData);
            };

            Post["/action"] = parameters =>
            {
                if (Convert.ToBoolean(ConfigurationManager.AppSettings["maintenanceMode"])) return Response.AsJson(new { data = "Service unavailable - Maintenance in progress" }, HttpStatusCode.ServiceUnavailable);
                
                try
                {
                    this.Info(() => "Api action started. TimeStamp: {0}".FormatWith(DateTime.UtcNow));
                    var apiRequest = this.Bind<ApiRequestDto>();
                    var token = Context.Request.Headers.Authorization.Split(' ')[1];

                    new ApiRequestValidator(userManagementApi)
                        .AuthenticateRequest(token, apiRequest.UserId, apiRequest.CustomerClientId, apiRequest.ContractId, apiRequest.PackageId);

                    this.Info(() => "Api request: ContractId {0} Api token:{1}".FormatWith(apiRequest.ContractId, token));
                    this.Info(() => "Api PB URI: {0}".FormatWith(ConfigurationManager.AppSettings["pbApi/config/baseUrl"]));

                    apiRequest.Validate();
                    apiRequest.ContractVersion((long)1.0); //TODO: Set here or in PB?
                    Context.Report(dispatcher, apiRequest.RequestId);

                    this.Info(() => "Api to PackageBuilder Execute Initialized. TimeStamp: {0}".FormatWith(DateTime.UtcNow));
                    var responses = packageBuilderApi.Post(token, "/Packages/Execute", null, apiRequest);
                    this.Info(() => "Api to PackageBuilder Execute Completed. TimeStamp: {0}".FormatWith(DateTime.UtcNow));

                    this.Info(() => "Api responses: {0}".FormatWith(responses));
                    this.Info(() => "Api action completed. TimeStamp: {0}".FormatWith(DateTime.UtcNow));

                    return responses;
                }
                catch (LightstoneAutoException ex)
                {
                    return Response.AsJson(new { error = ex.Message });
                }
                catch (TargetInvocationException)
                {
                    return Response.AsJson(new { error = "Ensure all properties are populated" });
                }
            };
        }
    }
}