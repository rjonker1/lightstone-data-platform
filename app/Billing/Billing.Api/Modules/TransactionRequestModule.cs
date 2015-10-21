using System;
using System.Linq;
using DataPlatform.Shared.Repositories;
using Shared.BuildingBlocks.Api.Security;
using Workflow.Billing.Domain.Entities;

namespace Billing.Api.Modules
{
    public class TransactionRequestModule : SecureModule
    {
        public TransactionRequestModule(IRepository<TransactionRequest> transactionRequestRepo)
        {
            Get["/Transactions/Requests/{requestId}"] = param =>
            {
                var requestId = new Guid(param.requestId);
                return transactionRequestRepo.Any(x => x.RequestId == requestId);
            };
        }
    }
}