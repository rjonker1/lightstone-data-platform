using Api.Scans.Verfication.Infrastructure.Dto;

namespace Api.Scans.Verfication.Core.Contracts
{
    public interface ICallUserManagement
    {
        AuthenticatedUserResponseDto ValidateUser(AuthenticateUserRequestDto request);

        AuthenticatedUserIdentityResponseDto ValidateUserWithToken(
            AuthenticatedUserIdentityRequestDto request);
    }
}
