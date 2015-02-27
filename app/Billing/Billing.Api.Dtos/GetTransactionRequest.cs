using System;

namespace Billing.Api.Dtos
{
    public class GetTransactionRequest
    {
        public Guid TransactionId { get; private set; }

        public GetTransactionRequest()
        {
        }

        public GetTransactionRequest(Guid transactionId)
        {
            TransactionId = transactionId;
        }
    }

    public class GetResponseRequest
    {
        public Guid TransactionId { get; private set; }

        public GetResponseRequest()
        {
        }

        public GetResponseRequest(Guid transactionId)
        {
            TransactionId = transactionId;
        }
    }
}