using Nancy.Security;

namespace Shared.BuildingBlocks.Api.Security
{
    public class UmApiAuthenticator : IUmApiAuthenticator
    {
        public IUserIdentity GetUserIdentity(string token)
        {
            return new UserManagementApiClient().Post<ApiUser>(token, "authenticate");
        }
    }
}