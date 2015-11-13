using System;
using System.Runtime.Serialization;
using EasyNetQ;

namespace DataPlatform.Shared.Messaging.Billing.Messages
{
    [Serializable]
    [DataContract]
    [Queue("DataPlatform.Transactions.Billing", ExchangeName = "DataPlatform.Transactions.Billing")]
    public class InvoiceTransactionCreated : IPublishableMessage
    {
        public InvoiceTransactionCreated()
        {
        }

        public InvoiceTransactionCreated(Guid transactionId)
        {
            TransactionId = transactionId;
        }

        [DataMember]
        public Guid TransactionId { get; private set; }
    }
}
