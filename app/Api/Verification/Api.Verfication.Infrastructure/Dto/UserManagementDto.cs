using System;
using System.Collections.Generic;
using Api.Verfication.Core.Contracts;
using Nancy.Security;

namespace Api.Verfication.Infrastructure.Dto
{
    public class AuthenticatedUserResponseDto : IHaveAuthenticatedUserResponse
    {
        public AuthenticatedUserResponseDto()
        {
            
        }

        public AuthenticatedUserResponseDto(Guid authenticationToken, string username, string authenticationStatus)
        {
            AuthenticationToken = authenticationToken;
            Username = username;
            AuthenticationStatus = authenticationStatus;
        }

        public string AuthenticationStatus { get; private set; }
        public Guid AuthenticationToken { get; private set; }
        public string Username { get; private set; }
    }

    public class AuthenticatedUserIdentityResponseDto : IHaveAuthenticatedUserIdentityResponse
    {
        public IUserIdentity UserIdentity { get; private set; }

        public AuthenticatedUserIdentityResponseDto(IUserIdentity userIdentity)
        {
            UserIdentity = userIdentity;
        }
    }

    public class AuthenticatedUserIdentityRequestDto : IHaveAuthenticatedUserIdentityRequest
    {
        public string AuthenticationToken { get; private set; }

        public AuthenticatedUserIdentityRequestDto(string authenticationToken)
        {
            AuthenticationToken = authenticationToken;
        }
    }

    public class AuthenticateUserRequestDto : IHaveAuthenticateUserRequest
    {
        public Guid AuthenticationToken { get; private set; }

        public AuthenticateUserRequestDto()
        {
            
        }

        public AuthenticateUserRequestDto(Guid authenticationToken)
        {
            AuthenticationToken = authenticationToken;
        }
    }

    public class UserIdentity : IUserIdentity
    {
        public UserIdentity(string userName)
        {
            UserName = userName;
        }

        public UserIdentity(string userName, IEnumerable<string> claims)
        {
            UserName = userName;
            Claims = claims;
        }

        public IEnumerable<string> Claims { get; private set; }
        public string UserName { get; private set; }
    }
}