using System;
using DataPlatform.Shared.Public.Helpers;
using DataPlatform.Shared.Public.Identifiers;

namespace Billing.Api.Dtos
{
    public class TransactionContext
    {
        public TransactionContext(Guid transactionId, UserIdentifier user, RequestIdentifier request)
        {
            TransactionId = transactionId;
            User = user;
            Request = request;
            TransactionDate = SystemTime.Now();
        }

        public DateTime TransactionDate { get; private set; }
        public Guid TransactionId { get; private set; }
        public UserIdentifier User { get; private set; }
        public RequestIdentifier Request { get; private set; }
    }
}