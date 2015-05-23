using System;
namespace Lim.Schedule.Core.Identifiers
{
    public class IntegrationClientIdentifier
    {
        public IntegrationClientIdentifier(Guid clientId, string accountNumber)
        {
            ClientId = clientId;
            AccountNumber = accountNumber;
        }
        public Guid ClientId { get; private set; }
        public string AccountNumber { get; private set; }
    }
}
