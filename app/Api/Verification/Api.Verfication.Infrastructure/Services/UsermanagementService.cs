using System;
using Api.Verfication.Core.Contracts;
using Api.Verfication.Infrastructure.Dto;

namespace Api.Verfication.Infrastructure.Services
{
    public class UserManagementService : ICallUserManagement
    {
        public IHaveAuthenticatedUserResponse ValidateUser(IHaveAuthenticateUserRequest request)
        {
            //TODO: Implement call to user management API
            return new AuthenticatedUserResponseDto(request.AuthenticationToken, "murrayw@lightstone.co.za",
                "authenticated");
        }

        public IHaveAuthenticatedUserIdentityResponse ValidateUserWithToken(
            IHaveAuthenticatedUserIdentityRequest request)
        {
            //TODO: Implement call to usermanagement API
            Guid token;
            return !Guid.TryParse(request.AuthenticationToken, out token)
                ? new AuthenticatedUserIdentityResponseDto(null)
                : new AuthenticatedUserIdentityResponseDto(new UserIdentity("murrayw@lightstone.co.za"));

        }
    }
}