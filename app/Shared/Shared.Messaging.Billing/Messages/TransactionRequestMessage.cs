using System;
using DataPlatform.Shared.Enums;
using EasyNetQ;

namespace DataPlatform.Shared.Messaging.Billing.Messages
{
    [Queue("DataPlatform.Transactions.Billing", ExchangeName = "DataPlatform.Transactions.Billing")]
    public class TransactionRequestMessage : IPublishableMessage
    {
        public virtual Guid RequestId { get; set; }
        public virtual ApiCommitRequestUserState UserState { get; set; }

        public TransactionRequestMessage()
        {
        }
    }
}