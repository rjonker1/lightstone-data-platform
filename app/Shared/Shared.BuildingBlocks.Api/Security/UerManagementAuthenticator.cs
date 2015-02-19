using Nancy.Security;
using Shared.BuildingBlocks.Api.ApiClients;

namespace Shared.BuildingBlocks.Api.Security
{
    public interface IAuthenticateThroughUserManagementApi : IAuthenticateUser
    {

    }

    public class UerManagementAuthenticator : IAuthenticateThroughUserManagementApi
    {
        private readonly IUserAuthenticationClient _userAuthenticationClient;

        public UerManagementAuthenticator(IUserAuthenticationClient userAuthenticationClient)
        {
            _userAuthenticationClient = userAuthenticationClient;
        }

        public IUserIdentity GetUserIdentity(string token)
        {
            return _userAuthenticationClient.Post<ApiUser>(token, "authenticate");
        }
    }
}