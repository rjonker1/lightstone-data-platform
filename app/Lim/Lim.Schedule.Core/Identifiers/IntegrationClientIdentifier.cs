using System;
using System.Collections.Generic;
using Lim.Dtos;

namespace Lim.Schedule.Core.Identifiers
{
    public class IntegrationClientIdentifier
    {
        public IntegrationClientIdentifier(IEnumerable<IntegrationClientDto> clients)
        {
            Clients = clients;
        }

        public IEnumerable<IntegrationClientDto> Clients;
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
