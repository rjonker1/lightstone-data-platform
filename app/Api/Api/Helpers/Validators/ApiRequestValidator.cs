﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Api.Domain.Infrastructure.Dto;
using DataPlatform.Shared.ExceptionHandling;
using Newtonsoft.Json;
using Shared.BuildingBlocks.Api.ApiClients;

namespace Api.Helpers.Validators
{
    public class ApiRequestValidator
    {
        private readonly IUserManagementApiClient _userManagementApiClient;
        private const string commercialState = "TRIAL";

        public ApiRequestValidator(IUserManagementApiClient userManagementApiClient)
        {
            _userManagementApiClient = userManagementApiClient;
        }

        public void AuthenticateRequest(string authToken, Guid userId, Guid customerClientId, Guid contractId, Guid packageId)
        {
            #region ValuePopulation Validation

            if (authToken == string.Empty) throw new LightstoneAutoException("Auth Token not found");
            if (userId == new Guid()) throw new LightstoneAutoException("UserId required");
            if (customerClientId == new Guid()) throw new LightstoneAutoException("customerClientId required");
            if (packageId == new Guid()) throw new LightstoneAutoException("packageId required");

            #endregion

            #region isLocked Validation

            // Validate User
            var user = JsonConvert.DeserializeObject<ValidationDto>(_userManagementApiClient.Get("", "/Users/Details/" + userId, "", new[] { new KeyValuePair<string, string>("Authorization", "Token " + authToken), new KeyValuePair<string, string>("Content-Type", "application/json"), }));
            
            if (user == null) throw new LightstoneAutoException("User: " + userId + " not found. Please make sure the UserId entered is correct. Alternatively please re-authenticate token.");
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

            #region TrialAccount Validation

            if (customer != null)
            {
                if (customer.CommercialStateValue.Equals(commercialState)) TrialValidation(customer);
            }

            if (customer == null)
            {
                if (client.CommercialStateValue.Equals(commercialState)) TrialValidation(client);
            }

            #endregion

            #region User Customer | Client relationship validation

            if (customer != null && user.Customers.All(x => x.Id != customerClientId)) throw new LightstoneAutoException("Customer relationship invalid for user: " + userId);
            if (customer == null && user.Clients.All(x => x.Id != customerClientId)) throw new LightstoneAutoException("Client relationship invalid for user: " + userId);

            #endregion

            #region Contract relationship validation

            // Validate Contract
            var contract = JsonConvert.DeserializeObject<ValidationDto>(_userManagementApiClient.Get("", "/Contracts/Details/" + contractId, "", new[] { new KeyValuePair<string, string>("Authorization", "Token " + authToken), new KeyValuePair<string, string>("Content-Type", "application/json"), }));

            // Package, Customer, Client relationship check
            if (contract != null)
            {
                if (contract.Packages.All(x => x.Key != packageId)) throw new LightstoneAutoException("Package relationship invalid for contract: " + contractId);
                if (customer != null && contract.Customers.All(x => x.Id != customerClientId)) throw new LightstoneAutoException("Customer relationship invalid for contract: " + contractId);
                if (customer == null && contract.Clients.All(x => x.Id != customerClientId)) throw new LightstoneAutoException("Client relationship invalid for contract: " + contractId);
            }

            #endregion
        }

        private void TrialValidation(ValidationDto dto)
        {
            if (dto.TrialExpiration < DateTime.Today) throw new LightstoneAutoException("CustomerClient: " + dto.Id + " trial period has expired");
        }
    }
}