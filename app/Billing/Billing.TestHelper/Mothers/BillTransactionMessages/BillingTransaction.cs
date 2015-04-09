using System;
using DataPlatform.Shared.Helpers;
using Shared.Public.TestHelpers.Packages;
using Shared.Public.TestHelpers.Requests;
using Shared.Public.TestHelpers.Users;

namespace Billing.TestHelper.Mothers.BillTransactionMessages
{
    public class BillingTransaction : IDefineBillingTransaction
    {
        public Guid TransactionId
        {
            get { return new Guid("D2BF35B5-FBEA-49C5-A78D-9539FC4AA2D4"); }
        }

        public DateTime TransactionDate
        {
            get { return SystemTime.Now(); }
        }

        public UserIdentifierBuilder UserIdentifier
        {
            get { return new UserIdentifierBuilder().With(new DefaultUserIdentifier()); }
        }

        public PackageIdentifierBuilder PackageIdentifier
        {
            get { return new PackageIdentifierBuilder().With(new DefaultPackageIdentifier()); }
        }

        public RequestIdentifierBuilder RequestIdentifier
        {
            get { return new RequestIdentifierBuilder().With(new DefaultRequestIdentifier()); }
        }

        public DataPlatform.Shared.Identifiers.ContractIdentifier Contract
        {
            get { return null; }
        }

        public DataPlatform.Shared.Identifiers.AccountIdentifier Account
        {
            get { return null; }
        }
    }
}