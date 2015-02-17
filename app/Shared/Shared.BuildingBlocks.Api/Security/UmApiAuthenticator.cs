using Nancy.Security;

namespace Shared.BuildingBlocks.Api.Security
{
    public class UmApiAuthenticator : IUmApiAuthenticator
    {
        public IUserIdentity GetUserIdentity(string token)
        {
            return new UserAuthenticatorClient().Post<ApiUser>(token, "authenticate");
        }
    }
}