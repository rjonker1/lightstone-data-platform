using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Api.Domain.Infrastructure.Dto;
using Api.Domain.Infrastructure.Extensions;
using DataPlatform.Shared.Dtos;
using DataPlatform.Shared.ExceptionHandling;
using Shared.BuildingBlocks.Api.ApiClients;

namespace Api.Helpers.Validators
{
    public interface IAuthenticateApi
    {
        void AuthenticateNewRequest(string authToken, CancellationToken ct, ApiRequestDto apiRequest);
        void AuthenticateExistingRequest(string authToken, CancellationToken ct, ApiCommitRequestDto apiRequest);
    }

    public class ApiRequestValidator : IAuthenticateApi
    {
        private readonly IUserManagementApiClient _userManagementApiClient;
        private const string CommercialState = "TRIAL";

        public ApiRequestValidator(IUserManagementApiClient userManagementApiClient)
        {
            _userManagementApiClient = userManagementApiClient;
        }

        public async void AuthenticateNewRequest(string authToken, CancellationToken cancellationToken, ApiRequestDto apiRequest)
        {
            var result = await ValidateUserCustomerContract(authToken, cancellationToken, apiRequest.UserId, apiRequest.CustomerClientId, apiRequest.ContractId,apiRequest.PackageId);
            apiRequest.Validate();
            apiRequest.ContractVersion(result.ContractVersion);
            apiRequest.SetContactNumber(result.ContactNumber);
        }

        public async void AuthenticateExistingRequest(string authToken, CancellationToken cancellationToken, ApiCommitRequestDto apiRequest)
        {
            var result = await ValidateUserCustomerContract(authToken, cancellationToken, apiRequest.UserId, apiRequest.CustomerClientId, apiRequest.ContractId, apiRequest.PackageId);
            apiRequest.Validate();
            apiRequest.SetContractVersion(result.ContractVersion);
            apiRequest.SetContactNumber(result.ContactNumber);
        }


        private async Task<AuthenticationResult> ValidateUserCustomerContract(string authToken, CancellationToken cancellationToken, Guid userId, Guid customerClientId, Guid contractId, Guid packageId)
        {
            #region ValuePopulation Validation

            if (authToken == string.Empty) throw new LightstoneAutoException("Auth Token not found");
            if (userId == new Guid()) throw new LightstoneAutoException("UserId required");
            if (customerClientId == new Guid()) throw new LightstoneAutoException("customerClientId required");
            if (packageId == new Guid()) throw new LightstoneAutoException("packageId required");

            #endregion

            #region isLocked Validation

            // Validate User
            var user = await _userManagementApiClient.GetAsync<ValidationDto>(authToken, cancellationToken, "/Users/Details/{id}",
                new[] {new KeyValuePair<string, string>("id", userId + "")}, null).ConfigureAwait(false);

            if (user == null)
                throw new LightstoneAutoException("User: " + userId + " not found. Please make sure the UserId entered is correct. Alternatively please re-authenticate token.");
            if (user.IsLocked) throw new LightstoneAutoException("User: " + userId + " is locked");

            //Validate Customer|Client
            var client = new ValidationDto();

            var customer = await _userManagementApiClient.GetAsync<ValidationDto>(authToken, cancellationToken, "Customers/Details/{id}",
                new[] {new KeyValuePair<string, string>("id", customerClientId + "")}, null);
            if (customer != null && customer.IsLocked) throw new LightstoneAutoException("Customer: " + customerClientId + " is locked");

            if (customer == null)
            {
                client = await _userManagementApiClient.GetAsync<ValidationDto>(authToken, cancellationToken, "/Clients/Details/{id}",
                    new[] {new KeyValuePair<string, string>("id", customerClientId + "")}, null);

                if (client == null) throw new LightstoneAutoException("CustomerClientId: " + customerClientId + " not found");

                if (client.IsLocked) throw new LightstoneAutoException("Client: " + customerClientId + " is locked");
            }

            #endregion

            #region TrialAccount Validation

            if (customer != null)
            {
                if (customer.CommercialStateValue.Equals(CommercialState)) TrialValidation(customer);
            }

            if (customer == null)
            {
                if (client.CommercialStateValue.Equals(CommercialState)) TrialValidation(client);
            }

            #endregion

            #region User Customer | Client relationship validation

            if (customer != null && user.Customers.All(x => x.Id != customerClientId))
                throw new LightstoneAutoException("Customer relationship invalid for user: " + userId);
            if (customer == null && user.Clients.All(x => x.Id != customerClientId))
                throw new LightstoneAutoException("Client relationship invalid for user: " + userId);

            #endregion

            #region Contract relationship validation

            // Validate Contract
            var contract = await _userManagementApiClient.GetAsync<ValidationDto>(authToken, cancellationToken, "/Contracts/Details/{id}",
                new[] {new KeyValuePair<string, string>("id", contractId + "")}, null);

            // Package, Customer, Client relationship check
            if (contract != null)
            {
                if (contract.Packages.All(x => x.Key != packageId))
                    throw new LightstoneAutoException("Package relationship invalid for contract: " + contractId);
                if (customer != null && contract.Customers.All(x => x.Id != customerClientId))
                    throw new LightstoneAutoException("Customer relationship invalid for contract: " + contractId);
                if (customer == null && contract.Clients.All(x => x.Id != customerClientId))
                    throw new LightstoneAutoException("Client relationship invalid for contract: " + contractId);
            }

            var contactNumber =  !string.IsNullOrEmpty(user.IndividualContactNumber) ? user.IndividualContactNumber : (customer == null || string.IsNullOrEmpty(customer.IndividualContactNumber) ? client.IndividualContactNumber : customer.IndividualContactNumber);
            
            return new AuthenticationResult(contactNumber,(long)1.0);
            
            #endregion
        }

        internal sealed class AuthenticationResult
        {
            public AuthenticationResult(string contactNumber, long contractVersion)
            {
                ContactNumber = contactNumber;
                ContractVersion = contractVersion;
            }

            public readonly string ContactNumber;
            public readonly long ContractVersion;
        }


        private static void TrialValidation(ValidationDto dto)
        {
            if (dto.TrialExpiration < DateTime.Today) throw new LightstoneAutoException("CustomerClient: " + dto.Id + " trial period has expired");
        }
    }
}