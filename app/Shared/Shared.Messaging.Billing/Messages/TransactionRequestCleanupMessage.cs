using System;
using EasyNetQ;

namespace DataPlatform.Shared.Messaging.Billing.Messages
{
    [Queue("DataPlatform.Transactions.Billing", ExchangeName = "DataPlatform.Transactions.Billing")]
    public class TransactionRequestCleanupMessage : IPublishableMessage
    {
        public virtual Guid RequestId { get; set; }

        public TransactionRequestCleanupMessage()
        {
        }
    }
}