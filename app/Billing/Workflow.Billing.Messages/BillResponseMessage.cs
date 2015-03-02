using System;
using DataPlatform.Shared.Identifiers;
using DataPlatform.Shared.Messaging;

namespace Workflow.Billing.Messages
{
    public class BillResponseMessage : IPublishableMessage
    {
        public BillResponseMessage()
        {
        }

        public BillResponseMessage(PackageIdentifier packageIdentifier, UserIdentifier userIdentifier,
            RequestIdentifier requestIdentifier,
            DateTime transactionDate, Guid requestId)
        {
            PackageIdentifier = packageIdentifier;
            UserIdentifier = userIdentifier;
            RequestIdentifier = requestIdentifier;
            TransactionDate = transactionDate;
            RequestId = requestId;
        }

        public PackageIdentifier PackageIdentifier { get; set; }
        public UserIdentifier UserIdentifier { get; set; }
        public RequestIdentifier RequestIdentifier { get; set; }
        public DateTime TransactionDate { get; set; }
        public Guid RequestId { get; set; }
    }
}
