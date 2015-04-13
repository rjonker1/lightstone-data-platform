using System;
using System.Runtime.Serialization;
using NServiceBus;

namespace DataPlatform.Shared.Messaging.Billing.Messages
{
    [Serializable]
    [DataContract]
    public class BillingTransactionCreated : IEvent
    {
        public BillingTransactionCreated(Guid transactionId)
        {
            TransactionId = transactionId;
        }

        [DataMember]
        public Guid TransactionId { get; private set; }
    }
}
