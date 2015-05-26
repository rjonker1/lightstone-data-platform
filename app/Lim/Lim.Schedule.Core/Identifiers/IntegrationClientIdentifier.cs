using System;
using System.Collections.Generic;

namespace Lim.Schedule.Core.Identifiers
{
    public class ClientAccount
    {
        public ClientAccount(Guid clientCustomerId, string accountNumber)
        {
            ClientCustomerId = clientCustomerId;
            AccountNumber = accountNumber;
        }
        
        public Guid ClientCustomerId { get; private set; }
        public string AccountNumber { get; private set; }
    }

    public class IntegrationClientIdentifier
    {
        public IntegrationClientIdentifier(IEnumerable<ClientAccount> clients)
        {
            Clients = clients;
        }

        public IEnumerable<ClientAccount> Clients;
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
