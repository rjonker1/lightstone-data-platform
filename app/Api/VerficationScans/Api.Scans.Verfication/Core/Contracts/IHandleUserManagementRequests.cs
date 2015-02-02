using Api.Scans.Verfication.Infrastructure.Commands;
using Api.Scans.Verfication.Infrastructure.Dto;

namespace Api.Scans.Verfication.Core.Contracts
{
    public interface IHandleUserManagementRequests
    {
        AuthenticatedUserResponseDto User { get; }

        void Handle(AuthenticateUserCommand command);
        void Handle(AuthenticateUserFromTokenCommand command);
    }
}
