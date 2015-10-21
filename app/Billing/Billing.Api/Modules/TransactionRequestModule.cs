using System;
using System.Linq;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.Repositories;
using Shared.BuildingBlocks.Api.Security;
using Workflow.Billing.Domain.Entities;

namespace Billing.Api.Modules
{
    public class TransactionRequestModule : SecureModule
    {
        public TransactionRequestModule(IRepository<TransactionRequest> transactionRequestRepo)
        {
            Get["/Transactions/Request/{requestId}/{state}"] = param =>
            {
                var requestId = new Guid(param.requestId);
                //var state = (ApiCommitRequestState) param.state;
                return transactionRequestRepo.Any(x => x.RequestId == requestId && x.ExpirationDate > DateTime.UtcNow);
            };
        }
    }
}