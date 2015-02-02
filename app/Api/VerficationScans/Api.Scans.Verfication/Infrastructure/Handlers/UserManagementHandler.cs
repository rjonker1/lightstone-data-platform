using Api.Scans.Verfication.Core.Contracts;
using Api.Scans.Verfication.Infrastructure.Commands;
using Api.Scans.Verfication.Infrastructure.Dto;

namespace Api.Scans.Verfication.Infrastructure.Handlers
{
    public class UserManagementRequestHandler : IHandleUserManagementRequests
    {
        public AuthenticatedUserResponseDto User { get; private set; }
        public AuthenticatedUserIdentityResponseDto UserIdentity { get; private set; }

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