using Api.Scans.Verfication.Infrastructure.Dto;

namespace Api.Scans.Verfication.Infrastructure.Commands
{
    public class AuthenticateUserCommand
    {
        public readonly AuthenticateUserRequestDto Request;

        public AuthenticateUserCommand(AuthenticateUserRequestDto request)
        {
            Request = request;
        }
    }

    public class AuthenticateUserFromTokenCommand
    {
        public readonly AuthenticatedUserIdentityRequestDto Request;

        public AuthenticateUserFromTokenCommand(AuthenticatedUserIdentityRequestDto request)
        {
            Request = request;
        }
    }
}