using System;
using DataPlatform.Shared.Messaging.Billing.Helpers;
using EasyNetQ;

namespace DataPlatform.Shared.Messaging.Billing.Messages
{
    [Queue("DataPlatform.Transactions.Billing", ExchangeName = "DataPlatform.Transactions.Billing")]
    public class ClientMessage : Entity
    {
        public virtual string AccountNumber { get; set; }
        public virtual Guid ClientId { get; set; }
        public virtual string ClientName { get; set; }

        public ClientMessage()
        {
        }
    }
}