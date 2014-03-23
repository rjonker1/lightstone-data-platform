using System;

namespace Billing.Api.Dtos
{
    public class CreateTransaction
    {
        public CreateTransaction()
        {
        }

        public CreateTransaction(Guid userId, Guid transactionId)
        {
            UserId = userId;
            TransactionId = transactionId;
        }

        public Guid UserId { get; private set; }
        public Guid TransactionId { get; private set; }
    }
}
