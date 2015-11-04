using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using Cradle.KeepAlive.Service.Helpers;
using DataPlatform.Shared.Dtos;
using Shared.BuildingBlocks.Api.ApiClients;

namespace Cradle.KeepAlive.Service.Domain
{
    public class PackageCheck
    {
        private readonly IApiClient _apiClient;

        public PackageCheck(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public void InvokePackage()
        {
            var token = new Login().GetToken();

            if (token != null)
            {
                var customerClientId = new Guid(ConfigurationManager.AppSettings["package/customerclientid"]);
                var userId = new Guid(ConfigurationManager.AppSettings["package/userid"]);
                var contractId = new Guid(ConfigurationManager.AppSettings["package/contractid"]);
                var packageId = new Guid(ConfigurationManager.AppSettings["package/packageid"]);
                var requestFields = new List<RequestFieldDto>();
                requestFields.Add(new RequestFieldDto
                {
                    Name = "VIN",
                    Value = "W0LPC6EC8DG072314",
                    Type = "0"
                });

                //var apiRequest = new ApiRequestDto(customerClientId, userId, contractId, packageId, Guid.NewGuid(), Guid.NewGuid(),);

                _apiClient.Post(token, "/action", null, new ApiCommitRequestDto
                {

                }, null);
            }
        }
    }
}