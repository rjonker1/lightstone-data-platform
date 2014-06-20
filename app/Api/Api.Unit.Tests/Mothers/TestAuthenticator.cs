using Nancy.Security;
using Shared.BuildingBlocks.Api.Security;

namespace Api.Unit.Tests.Mothers
{
    public class TestAuthenticator : IAuthenticateUser
    {
        public IUserIdentity GetUserIdentity(string token)
        {
            return new ApiUser("testUser");
        }
    }
}