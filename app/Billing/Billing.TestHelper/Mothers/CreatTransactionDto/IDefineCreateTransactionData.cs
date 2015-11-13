using Billing.Api.Dtos;
using DataPlatform.Shared.Identifiers;

namespace Billing.TestHelper.Mothers.CreatTransactionDto
{
    public interface IDefineCreateTransactionData
    {
        TransactionContext Context { get; }
        PackageIdentifier Package { get; }
        ContractIdentifier Contract { get; }
        AccountIdentifier Account { get; }
    }
}