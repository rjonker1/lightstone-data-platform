using System;
using System.Data;

namespace EventTracking.Domain.Core.Contracts
{
    public interface IHandleTransactions : IDisposable
    {
        void BeginTransaction();
        void BeginTransaction(IsolationLevel level);
        void CommitTransaction();
    }
}
