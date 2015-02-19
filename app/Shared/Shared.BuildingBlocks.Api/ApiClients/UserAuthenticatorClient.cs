namespace Shared.BuildingBlocks.Api.ApiClients
{
    public interface IUserAuthenticationClient : IApiClient
    {
        
    }

    public class UserAuthenticatorClient : ApiClientBase, IUserAuthenticationClient
    {
        public UserAuthenticatorClient()
            : base(AppSettings.UserManagementApi.BaseUrl)
        {
        }
    }
}