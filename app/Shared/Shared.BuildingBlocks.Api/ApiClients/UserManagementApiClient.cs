namespace Shared.BuildingBlocks.Api.ApiClients
{
    public interface IUserManagementApiClient : IApiClient
    {

    }

    public class UserManagementApiClient : ApiClientBase, IUserManagementApiClient
    {
        public UserManagementApiClient() : base(AppSettings.UserManagementApi.BaseUrl)
        {
        }
    }
}