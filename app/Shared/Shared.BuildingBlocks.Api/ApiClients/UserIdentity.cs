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

        public UserIdentity(bool hasMultipleCustomersClients, bool hasMultipleContracts, bool hasMultiplePackages, Guid customerClientId, Guid contractId, Guid packageId, Guid userId, string userName, IEnumerable<string> claims)
        {
            HasMultipleCustomersClients = hasMultipleCustomersClients;
            HasMultipleContracts = hasMultipleContracts;
            HasMultiplePackages = hasMultiplePackages;
            CustomerClientId = customerClientId;
            ContractId = contractId;
            PackageId = packageId;
            UserId = userId;
            UserName = userName;
            Claims = claims;
        }


        public bool HasMultipleCustomersClients { get; private set; }
        public bool HasMultipleContracts { get; private set; }
        public bool HasMultiplePackages { get; private set; }
        public Guid CustomerClientId { get; private set; }
        public Guid ContractId { get; private set; }
        public Guid PackageId { get; private set; }
        public Guid UserId { get; private set; }
        public string UserName { get; private set; }
        public IEnumerable<string> Claims { get; private set; }
    }
}