using System;

namespace Billing.Api.Tests.Mothers.CreatTransactionDto
{
    public class DefaultCreateTransactionData : IDefineCreateTransactionData
    {
        public Guid UserId
        {
            get { return new Guid("58C0A604-C26A-4C5E-9B3A-B63D6AF15822"); }
        }

        public Guid TransactionId
        {
            get { return new Guid("32E36FFC-8ECC-49C9-A2B5-B3BB0AA493D8"); }
        }
    }
}