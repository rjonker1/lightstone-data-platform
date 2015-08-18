using System;
using System.Collections.Generic;
using Nancy.Security;

namespace Shared.BuildingBlocks.Api.ApiClients
{
    public class UserIdentity : IUserIdentity
    {
        public UserIdentity()
        {
        }

        public UserIdentity(Guid userId, string userName, params string[] roles)
        {
            UserId = userId;
            UserName = userName;
            Claims = roles;
        }

        public Guid UserId { get; private set; }
        public string UserName { get; private set; }
        public IEnumerable<string> Claims { get; private set; }
    }
}