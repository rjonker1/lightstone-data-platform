using System;
using System.Collections.Generic;
using System.Configuration;
using Cradle.KeepAlive.Service.Helpers;
using Cradle.KeepAlive.Service.Helpers.Notifications;
using DataPlatform.Shared.Dtos;
using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using Shared.BuildingBlocks.Api.ApiClients;

namespace Cradle.KeepAlive.Service.Domain
{
    public class PackageCheck : EmailAlert
    {
        private readonly IApiClient _apiClient;

        public PackageCheck(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public void InvokePackage()
        {
            try
            {
                var token = new Login().GetToken();

                if (token != null)
                {
                    var customerClientId = new Guid(ConfigurationManager.AppSettings["package/customerclientid"]);
                    var userId = new Guid(ConfigurationManager.AppSettings["package/userid"]);
                    var contractId = new Guid(ConfigurationManager.AppSettings["package/contractid"]);
                    var packageId = new Guid(ConfigurationManager.AppSettings["package/packageid"]);
                    var requestFields = new List<RequestFieldDto>
                    {
                        new RequestFieldDto
                        {
                            Name = "VIN",
                            Value = "W0LPC6EC8DG072314",
                            Type = "0"
                        }
                    };

                    this.Info(() => "Initiating package invocation");
                    var response = _apiClient.Post(token, "/action", null, new ApiRequestDto(customerClientId, userId, contractId, packageId, requestFields, false), null);

                    if (response.Contains("error")) throw new LightstoneAutoException(response);
                    this.Info(() => "Package invocation complete");
                }
            }
            catch (Exception e)
            {
                this.Error(() => e.Message);
                SendEmail("Package invocation error", e.Message);
            }
        }
    }
}