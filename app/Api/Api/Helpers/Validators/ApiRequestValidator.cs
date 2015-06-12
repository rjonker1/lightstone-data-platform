using System;
using System.Collections.Generic;
using Api.Domain.Infrastructure.Dto;
using DataPlatform.Shared.ExceptionHandling;
using Newtonsoft.Json;
using Shared.BuildingBlocks.Api.ApiClients;

namespace Api.Helpers.Validators
{
    public class ApiRequestValidator
    {
        private readonly IUserManagementApiClient _userManagementApiClient;

        public ApiRequestValidator(IUserManagementApiClient userManagementApiClient)
        {
            _userManagementApiClient = userManagementApiClient;
        }

        public void AuthenticateRequest(string authToken, Guid userId, Guid customerClientId)
        {
            #region ValuePopulation Validation

            if (authToken == string.Empty) throw new LightstoneAutoException("Auth Token not found");
            if (userId == new Guid()) throw new LightstoneAutoException("UserId required");
            if (customerClientId == new Guid()) throw new LightstoneAutoException("customerClientId required");

            #endregion

            #region isLocked Validation

            // Validate User
            var user = JsonConvert.DeserializeObject<ValidationDto>(_userManagementApiClient.Get("", "/Users/Details/" + userId, "", new[] { new KeyValuePair<string, string>("Authorization", "Token " + authToken), new KeyValuePair<string, string>("Content-Type", "application/json"), }));
            
            if (user == null) throw new LightstoneAutoException("User: " + userId + " not found");
            if (user.IsLocked) throw new LightstoneAutoException("User: " + userId + " is locked");
            
            //Validate Customer|Client
            var client = new ValidationDto();

            var customer = JsonConvert.DeserializeObject<ValidationDto>(_userManagementApiClient.Get("", "/Customers/Details/" + customerClientId, "", new[] { new KeyValuePair<string, string>("Authorization", "Token " + authToken), new KeyValuePair<string, string>("Content-Type", "application/json"), }));
            if (customer != null && customer.IsLocked) throw new LightstoneAutoException("Customer: " + customerClientId + " is locked");

            if (customer == null)
            {
                client = JsonConvert.DeserializeObject<ValidationDto>(_userManagementApiClient.Get("", "/Clients/Details/" + customerClientId, "", new[] { new KeyValuePair<string, string>("Authorization", "Token " + authToken), new KeyValuePair<string, string>("Content-Type", "application/json"), }));

                if (client == null) throw new LightstoneAutoException("CustomerClientId: " + customerClientId + " not found");
                
                if (client.IsLocked) throw new LightstoneAutoException("Client: " + customerClientId + " is locked");
            }

            #endregion


            // Validate Contract
            //var contract = JsonConvert.DeserializeObject<ValidationDto>(_userManagementApiClient.Get("", "/Customers/Details/" + customerClientId, "", new[] { new KeyValuePair<string, string>("Authorization", "Token " + authToken), new KeyValuePair<string, string>("Content-Type", "application/json"), }));



            // TODO: Validate Customer | Client
            // TODO: Validate Contract
            // TODO: Validate Package

        }
    }
}