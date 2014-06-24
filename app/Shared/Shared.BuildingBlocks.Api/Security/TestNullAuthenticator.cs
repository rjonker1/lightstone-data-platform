using Nancy.Security;

namespace Shared.BuildingBlocks.Api.Security
{
    public class TestNullAuthenticator : IAuthenticateUser
    {
        public IUserIdentity GetUserIdentity(string token)
        {
            return null;
        }
    }
}