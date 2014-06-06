using System;
using Billing.Api.Dtos;
using DataPlatform.Shared.Public.Helpers;
using DataPlatform.Shared.Public.Identifiers;

namespace Billing.Api.Tests.Mothers.CreatTransactionDto
{
    public class DefaultCreateTransactionData : IDefineCreateTransactionData
    {
        public TransactionContext Context
        {
            get
            {
                return new TransactionContext(new UserIdentifier(new Guid("58C0A604-C26A-4C5E-9B3A-B63D6AF15822")),
                    new RequestIdentifier(new Guid("32E36FFC-8ECC-49C9-A2B5-B3BB0AA493D8"), new SystemIdentifier("TEST")));
            }
        }

        public PackageIdentifier Package
        {
            get { return new PackageIdentifier(new Guid("32E36FFC-8ECC-49C9-A2B5-B3BB0AA49852"), new VersionIdentifier(1, SystemTime.Now())); }
        }
    }
}