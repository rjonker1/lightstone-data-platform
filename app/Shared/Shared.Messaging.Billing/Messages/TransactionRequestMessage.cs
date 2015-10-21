using System;
using EasyNetQ;

namespace DataPlatform.Shared.Messaging.Billing.Messages
{
    [Queue("DataPlatform.Transactions.Billing", ExchangeName = "DataPlatform.Transactions.Billing")]
    public class TransactionRequestMessage : IPublishableMessage
    {
        public virtual Guid RequestId { get; set; }

        public TransactionRequestMessage()
        {
        }
    }
}