using System;

namespace Lace.Domain.Core.Contracts.Requests
{
    public interface IProvideFicaInformationForRequest
    {
        long IdNumber { get; }
        string Username { get; }
        int FicaTransactionId { get; }
        Guid TransactionToken { get; }
    }
}
