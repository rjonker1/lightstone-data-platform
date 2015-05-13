using System;

namespace Lim.Domain.Contracts
{
    public interface ISchedulePullForApi
    {
        Guid ClientId { get; }
        string AccountNumber { get; }
        Guid TransactionId { get; }

    }
}
