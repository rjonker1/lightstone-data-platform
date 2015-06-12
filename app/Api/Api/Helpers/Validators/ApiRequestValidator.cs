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

        public string AuthenticateRequest()
        {
            // TODO: Validate User
            // TODO: Validate Customer | Client
            // TODO: Validate Contract
            // TODO: Validate Package
        }
    }
}