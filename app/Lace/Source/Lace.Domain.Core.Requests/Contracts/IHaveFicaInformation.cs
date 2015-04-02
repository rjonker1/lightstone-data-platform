using System;

namespace Lace.Domain.Core.Requests.Contracts
{
    public interface IHaveFicaInformation
    {
        long IdNumber { get; }
        string Username { get; }
        int FicaTransactionId { get; }
        Guid TransactionToken { get; }
    }
}
