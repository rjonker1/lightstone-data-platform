using Api.Verfication.Core.Contracts;

namespace Api.Verfication.Infrastructure.Commands
{
    public class AuthenticateUserCommand
    {
        public readonly IHaveAuthenticateUserRequest Request;

        public AuthenticateUserCommand(IHaveAuthenticateUserRequest request)
        {
            Request = request;
        }
    }

    public class AuthenticateUserFromTokenCommand
    {
        public readonly IHaveAuthenticatedUserIdentityRequest Request;

        public AuthenticateUserFromTokenCommand(IHaveAuthenticatedUserIdentityRequest request)
        {
            Request = request;
        }
    }
}