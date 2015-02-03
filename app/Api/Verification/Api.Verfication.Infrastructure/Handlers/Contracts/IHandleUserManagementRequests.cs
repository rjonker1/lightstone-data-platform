using Api.Verfication.Core.Contracts;
using Api.Verfication.Infrastructure.Commands;

namespace Api.Verfication.Infrastructure.Handlers.Contracts
{
    public interface IHandleUserManagementRequests
    {
        IHaveAuthenticatedUserResponse User { get; }

        void Handle(AuthenticateUserCommand command);
        void Handle(AuthenticateUserFromTokenCommand command);
    }
}
