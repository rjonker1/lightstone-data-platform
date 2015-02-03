using System;
using Nancy.Security;

namespace Api.Verfication.Core.Contracts
{
    public interface IHaveAuthenticatedUserIdentityResponse
    {
        IUserIdentity UserIdentity { get; }
    }

    public interface IHaveAuthenticatedUserIdentityRequest
    {
        string AuthenticationToken { get; }
    }

    public interface IHaveAuthenticateUserRequest
    {
        Guid AuthenticationToken { get; }
    }

    public interface IHaveAuthenticatedUserResponse
    {
        string AuthenticationStatus { get; }
        Guid AuthenticationToken { get; }
        string Username { get; }
    }
}
