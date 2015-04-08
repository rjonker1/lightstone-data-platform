using System;
using DataPlatform.Shared.Identifiers;
using Shared.Public.TestHelpers.Packages;
using Shared.Public.TestHelpers.Requests;
using Shared.Public.TestHelpers.Users;

namespace Billing.TestHelper.Mothers.BillTransactionMessages
{
    public interface IDefineBillingTransaction
    {
        Guid TransactionId { get; }
        DateTime TransactionDate { get; }
        UserIdentifierBuilder UserIdentifier { get; }

        PackageIdentifierBuilder PackageIdentifier { get; }
        RequestIdentifierBuilder RequestIdentifier { get; }
        ContractIdentifier Contract { get; }
        AccountIdentifier Account { get; }

    }
}