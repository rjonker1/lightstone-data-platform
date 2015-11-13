using System;
using System.Linq;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.Repositories;
using Nancy;
using Shared.BuildingBlocks.Api.Security;
using Workflow.Billing.Domain.Entities;

namespace Billing.Api.Modules
{
    public class TransactionRequestModule : SecureModule
    {
        public TransactionRequestModule(IRepository<TransactionRequest> transactionRequestRepo)
        {
            Get["/Transactions/Request/{requestId}"] = param =>
            {
                var requestId = new Guid(param.requestId);

                if (!transactionRequestRepo.Any(x => x.RequestId == requestId && x.ExpirationDate > DateTime.UtcNow))
                    return Response.AsJson(new { Error = "Request expired" });

                if (transactionRequestRepo.Any(x => x.RequestId == requestId && x.UserState == ApiCommitRequestUserState.Cancelled))
                    return Response.AsJson(new { Error = "Request cancelled by user" });

                if (transactionRequestRepo.Any(x => x.RequestId == requestId && x.ExpirationDate > DateTime.UtcNow))
                    return Response.AsJson(new { Success = "Request valid" });

                return Response.AsJson(new { Error = "Technical error" });
            };
        }
    }
}