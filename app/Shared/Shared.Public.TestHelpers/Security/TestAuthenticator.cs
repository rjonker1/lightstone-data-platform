using System;
using Nancy.Security;
using Shared.BuildingBlocks.Api.ApiClients;
using Shared.BuildingBlocks.Api.Security;

namespace Shared.Public.TestHelpers.Security
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
            return new UserIdentity(new Guid(), _username);
        }
    }
}