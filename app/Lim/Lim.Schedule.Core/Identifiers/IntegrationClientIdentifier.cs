using System;
using System.Collections.Generic;
using Lim.Domain.Models;

namespace Lim.Schedule.Core.Identifiers
{
    public class IntegrationClientIdentifier
    {
        public IntegrationClientIdentifier(IEnumerable<IntegrationClient> clients)
        {
            Clients = clients;
        }

        public IEnumerable<IntegrationClient> Clients;
    }

    public class IntegrationContractIdentifier
    {
        public IntegrationContractIdentifier(IEnumerable<Guid> contractIds)
        {
            ContractIds = contractIds;
        }
        public IEnumerable<Guid> ContractIds { get; private set; }
    }
}
