using Api.Verfication.Core.Contracts;
using Api.Verfication.Infrastructure.Commands;
using Api.Verfication.Infrastructure.Handlers.Contracts;

namespace Api.Verfication.Infrastructure.Handlers
{
    public class UserManagementRequestHandler : IHandleUserManagementRequests
    {
        public IHaveAuthenticatedUserResponse User { get; private set; }
        public IHaveAuthenticatedUserIdentityResponse UserIdentity { get; private set; }

        private readonly ICallUserManagement _service;

        public UserManagementRequestHandler(ICallUserManagement service)
        {
            _service = service;
        }

        public void Handle(AuthenticateUserCommand command)
        {
            User = _service.ValidateUser(command.Request);
        }

        public void Handle(AuthenticateUserFromTokenCommand command)
        {
            UserIdentity = _service.ValidateUserWithToken(command.Request);
        }
    }
}