using Nancy.Security;
using Shared.BuildingBlocks.Api.ApiClients;

namespace Shared.BuildingBlocks.Api.Security
{
    public class TestAuthenticator : IAuthenticateUser
    {
        private readonly string _username;

        public TestAuthenticator(string username)
        {
            _username = username;
        }

        public IUserIdentity GetUserIdentity(string token)
        {
            return new ApiUser(_username);
        }
    }
}