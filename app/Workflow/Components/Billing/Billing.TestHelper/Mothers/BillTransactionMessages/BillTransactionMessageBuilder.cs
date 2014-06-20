using System;
using DataPlatform.Shared.Identifiers;
using Shared.Public.TestHelpers.Packages;
using Shared.Public.TestHelpers.Requests;
using Shared.Public.TestHelpers.Users;
using Workflow.Billing.Messages;

namespace Billing.TestHelper.Mothers.BillTransactionMessages
{
    public class BillTransactionMessageBuilder
    {
        private PackageIdentifier packageIdentifier;
        private RequestIdentifier requestIdentifier;
        private DateTime transactionDate;
        private Guid transactionId;
        private UserIdentifier userIdentifier;

        public BillTransactionMessage Build()
        {
            return new BillTransactionMessage(packageIdentifier, userIdentifier, requestIdentifier, transactionDate, transactionId);
        }

        public BillTransactionMessageBuilder With(IDefineBillingTransaction data)
        {
            return WithPackageBuilder(data.PackageIdentifier)
                .WithRequestBuilder(data.RequestIdentifier)
                .WithTransactionDate(data.TransactionDate)
                .WithTransactionId(data.TransactionId)
                .WithUserIdentifierBuilder(data.UserIdentifier);
        }

        public BillTransactionMessageBuilder WithPackageBuilder(PackageIdentifierBuilder packageBuilder)
        {
            this.packageIdentifier = packageBuilder.Build();
            return this;
        }

        public BillTransactionMessageBuilder WithRequestBuilder(RequestIdentifierBuilder requestIdentifierBuilder)
        {
            this.requestIdentifier = requestIdentifierBuilder.Build();
            return this;
        }

        public BillTransactionMessageBuilder WithUserIdentifierBuilder(UserIdentifierBuilder userBuilder)
        {
            this.userIdentifier = userBuilder.Build();
            return this;
        }

        public BillTransactionMessageBuilder WithTransactionId(Guid transactionId)
        {
            this.transactionId = transactionId;
            return this;
        }

        public BillTransactionMessageBuilder WithTransactionDate(DateTime transactionDate)
        {
            this.transactionDate = transactionDate;
            return this;
        }
    }
}