using System;

namespace Billing.Api.Dtos
{
    public class GetTransactionResponse
    {
        public GetTransactionResponse()
        {
        }

        public GetTransactionResponse(Guid transactionId)
        {
            TransactionId = transactionId;
        }

        public Guid TransactionId { get; private set; }
    }
}