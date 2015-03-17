using System;
using DataPlatform.Shared.Identifiers;
using Workflow.Billing.Messages;

namespace Workflow.Lace.Messages.Events
{
    //public class TransactionCreated : IPublishableMessage
    //{
    //    public TransactionCreated(PackageIdentifier packageIdentifier, UserIdentifier userIdentifier,
    //        RequestIdentifier requestIdentifier,
    //        DateTime transactionDate)
    //    {
    //        PackageIdentifier = packageIdentifier;
    //        UserIdentifier = userIdentifier;
    //        RequestIdentifier = requestIdentifier;
    //        TransactionDate = transactionDate;
    //       // TransactionId = transactionId;
    //    }

    //    public PackageIdentifier PackageIdentifier { get; private set; }
    //    public UserIdentifier UserIdentifier { get; private set; }
    //    public RequestIdentifier RequestIdentifier { get; private set; }
    //    public DateTime TransactionDate { get; private set; }
    //    //public Guid TransactionId { get; private set; }
    //    public Guid Id { get; set; }

    //}

    public class TransactionCreated : BillTransactionMessage
    {
        public TransactionCreated(PackageIdentifier packageIdentifier, UserIdentifier userIdentifier,
            RequestIdentifier requestIdentifier,
            DateTime transactionDate, Guid id) :
                base(packageIdentifier, userIdentifier, requestIdentifier, transactionDate, id)
        {
        }

        public Guid Id { get; set; }
    }
}
