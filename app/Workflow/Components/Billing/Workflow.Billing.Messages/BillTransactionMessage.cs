using System;
using DataPlatform.Shared.Public.Messaging;

namespace Workflow.Billing.Messages
{
    public class BillTransactionMessage : IPublishableMessage
    {
        public Guid UserId { get; private set; }
        public Guid TransactionId { get; private set; }

        public BillTransactionMessage()
        {
        }

        public BillTransactionMessage(Guid userId, Guid transactionId)
        {
            UserId = userId;
            TransactionId = transactionId;
        }
    }
}
