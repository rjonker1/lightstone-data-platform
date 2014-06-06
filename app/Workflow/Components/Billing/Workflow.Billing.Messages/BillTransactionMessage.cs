using System;
using DataPlatform.Shared.Public.Identifiers;
using DataPlatform.Shared.Public.Messaging;

namespace Workflow.Billing.Messages
{
    public class BillTransactionMessage : IPublishableMessage
    {
        public BillTransactionMessage()
        {
        }

        public BillTransactionMessage(PackageIdentifier packageIdentifier, UserIdentifier userIdentifier, RequestIdentifier request,
            DateTime transactionDate, Guid transactionId)
        {
            PackageIdentifier = packageIdentifier;
            UserIdentifier = userIdentifier;
            Request = request;
            TransactionDate = transactionDate;
            TransactionId = transactionId;
        }

        public PackageIdentifier PackageIdentifier { get; private set; }
        public UserIdentifier UserIdentifier { get; private set; }
        public RequestIdentifier Request { get; private set; }
        public DateTime TransactionDate { get; private set; }
        public Guid TransactionId { get; private set; }
    }
}