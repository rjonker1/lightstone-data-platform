using System;

namespace Billing.Api.Tests.Mothers.CreatTransactionDto
{
    public interface IDefineCreateTransactionData
    {
        Guid UserId { get; }
        Guid TransactionId { get; }
    }
}