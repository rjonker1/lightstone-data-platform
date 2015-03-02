using System;
using DataPlatform.Shared.Identifiers;
using DataPlatform.Shared.Messaging;

namespace Workflow.Billing.Messages
{
    public class BillTransactionMessage : IPublishableMessage
    {
        public BillTransactionMessage()
        {
        }

        public BillTransactionMessage(PackageIdentifier packageIdentifier, UserIdentifier userIdentifier,
            RequestIdentifier requestIdentifier,
            DateTime transactionDate, Guid transactionId)
        {
            PackageIdentifier = packageIdentifier;
            UserIdentifier = userIdentifier;
            RequestIdentifier = requestIdentifier;
            TransactionDate = transactionDate;
            TransactionId = transactionId;
        }

        public PackageIdentifier PackageIdentifier { get; set; }
        public UserIdentifier UserIdentifier { get; set; }
        public RequestIdentifier RequestIdentifier { get; set; }
        public DateTime TransactionDate { get; set; }
        public Guid TransactionId { get; set; }
    }
}