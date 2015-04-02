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

        public UserIdentity(string userName)
        {
            UserName = userName;
            Claims = new List<string>();
        }

        public Guid Id { get; set; }
        public string UserName { get; set; }
        public IEnumerable<string> Claims { get; set; }
    }
}