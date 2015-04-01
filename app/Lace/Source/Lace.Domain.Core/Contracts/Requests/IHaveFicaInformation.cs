using System;

namespace Lace.Domain.Core.Contracts.Requests
{
    public interface IHaveFicaInformation
    {
        long IdNumber { get; }
        string Username { get; }
        int FicaTransactionId { get; }
        Guid TransactionToken { get; }
    }
}
