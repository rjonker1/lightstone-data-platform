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

        public Guid CustomerClientId { get; private set; }
        public Guid ContractId { get; private set; }
        public Guid PackageId { get; private set; }
        public Guid UserId { get; private set; }
        public string UserName { get; set; }
        public IEnumerable<string> Claims { get; set; }
    }
}