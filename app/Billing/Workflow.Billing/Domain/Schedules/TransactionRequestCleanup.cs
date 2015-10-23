using System;
using System.Linq;
using DataPlatform.Shared.Repositories;
using Workflow.Billing.Domain.Entities;

namespace Workflow.Billing.Domain.Schedules
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
            var test = _transactionRequests;
        }
    }
}