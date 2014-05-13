using Nancy.Security;
using Shared.BuildingBlocks.Api.Security;

namespace UmApi
{
    public class UmAuthenticator : IUmAuthenticator
    {
        public IUserIdentity GetUserIdentity(string token)
        {
            return UserDatabase.GetUserFromApiKey(token);
        }
    }
}