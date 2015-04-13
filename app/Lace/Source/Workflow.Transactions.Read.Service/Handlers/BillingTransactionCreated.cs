using System;
using System.Reflection;
using System.Runtime.Serialization;
using DataPlatform.Shared.Messaging;
using NServiceBus;

namespace Workflow.Transactions.Read.Service.Handlers
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
