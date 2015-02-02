using System;
using Api.Scans.Verfication.Core.Contracts;
using Api.Scans.Verfication.Infrastructure.Dto;

namespace Api.Scans.Verfication.Infrastructure.Services
{
    public class UserManagementService : ICallUserManagement
    {
        public AuthenticatedUserResponseDto ValidateUser(AuthenticateUserRequestDto request)
        {
            //TODO: Implement call to user management API
            return  new AuthenticatedUserResponseDto(request.AuthenticationToken,"murrayw@lightstone.co.za", "authenticated");
        }

        public AuthenticatedUserIdentityResponseDto ValidateUserWithToken(AuthenticatedUserIdentityRequestDto request)
        {
            //TODO: Implement call to usermanagement API
            Guid token;
            return !Guid.TryParse(request.AuthenticationToken, out token)
                ? new AuthenticatedUserIdentityResponseDto(null)
                : new AuthenticatedUserIdentityResponseDto(new UserIdentity("murrayw@lightstone.co.za"));

        }
    }
}