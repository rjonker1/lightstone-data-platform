using System;
using System.Runtime.Serialization;
using NServiceBus;

namespace DataPlatform.Shared.Messaging.Billing.Messages
{
    [Serializable]
    [DataContract]
    public class InvoiceTransactionCreated : IEvent
    {
        public InvoiceTransactionCreated() { }

        public InvoiceTransactionCreated(Guid transactionId)
        {
            TransactionId = transactionId;
        }

        [DataMember]
        public Guid TransactionId { get; private set; }
    }
}
