using Nancy.Security;

namespace Shared.BuildingBlocks.Api.Security
{
    public interface IAuthenticateUser
    {
        IUserIdentity GetUserIdentity(string token);
    }

    public interface IRedisAuthenticator : IAuthenticateUser
    {
        
    } 
}
