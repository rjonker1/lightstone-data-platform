namespace Api.Verfication.Core.Contracts
{
    public interface ICallUserManagement
    {
        IHaveAuthenticatedUserResponse ValidateUser(IHaveAuthenticateUserRequest request);

        IHaveAuthenticatedUserIdentityResponse ValidateUserWithToken(
            IHaveAuthenticatedUserIdentityRequest request);
    }
}
