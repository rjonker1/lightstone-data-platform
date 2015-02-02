using System;
using System.Collections.Generic;
using Nancy.Security;

namespace Api.Scans.Verfication.Infrastructure.Dto
{
    public class AuthenticatedUserResponseDto
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

        public readonly string AuthenticationStatus;
        public readonly Guid AuthenticationToken;
        public readonly string Username;
    }

    public class AuthenticatedUserIdentityResponseDto
    {
        public readonly IUserIdentity UserIdentity;

        public AuthenticatedUserIdentityResponseDto(IUserIdentity userIdentity)
        {
            UserIdentity = userIdentity;
        }
    }

    public class AuthenticatedUserIdentityRequestDto
    {
        public readonly string AuthenticationToken;

        public AuthenticatedUserIdentityRequestDto(string authenticationToken)
        {
            AuthenticationToken = authenticationToken;
        }
    }

    public class AuthenticateUserRequestDto
    {
        public readonly Guid AuthenticationToken;

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