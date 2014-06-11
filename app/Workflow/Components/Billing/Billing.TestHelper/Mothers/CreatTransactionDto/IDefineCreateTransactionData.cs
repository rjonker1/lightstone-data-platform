using Billing.Api.Dtos;
using DataPlatform.Shared.Public.Identifiers;

namespace Billing.TestHelper.Mothers.CreatTransactionDto
{
    public interface IDefineCreateTransactionData
    {
        TransactionContext Context { get; }
        PackageIdentifier Package { get; }
    }
}