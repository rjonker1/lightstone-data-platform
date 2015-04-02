using Nancy.Security;
using Shared.BuildingBlocks.Api.Security;

namespace Shared.Public.TestHelpers.Security
{
    public class TestNullAuthenticator : IAuthenticateUser
    {
        public IUserIdentity GetUserIdentity(string token)
        {
            return null;
        }
    }
}