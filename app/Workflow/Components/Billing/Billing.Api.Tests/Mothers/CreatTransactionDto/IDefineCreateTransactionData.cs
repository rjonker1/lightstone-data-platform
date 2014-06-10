using System;
using Billing.Api.Dtos;
using DataPlatform.Shared.Public.Identifiers;

namespace Billing.Api.Tests.Mothers.CreatTransactionDto
{
    public interface IDefineCreateTransactionData
    {
        TransactionContext Context { get; }
        PackageIdentifier Package { get; }
    }
}