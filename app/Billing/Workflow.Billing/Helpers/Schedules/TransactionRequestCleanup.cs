using System;
using System.Linq;
using DataPlatform.Shared.Repositories;
using Workflow.Billing.Domain.Entities;

namespace Workflow.Billing.Helpers.Schedules
{
    public class TransactionRequestCleanup : ICleanup
    {
        private readonly IRepository<TransactionRequest> _transactionRequests;
        public TransactionRequestCleanup(IRepository<TransactionRequest> transactionRequests)
        {
            _transactionRequests = transactionRequests;
        }

        public void Clean()
        {
            if (!_transactionRequests.Any()) return;

            foreach (var transactionRequest in _transactionRequests)
            {
                _transactionRequests.Delete(transactionRequest);
            }
        }
    }
}