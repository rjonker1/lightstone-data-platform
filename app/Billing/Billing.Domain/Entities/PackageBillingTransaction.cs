using System;
using System.Linq;
using Billing.Domain.Dtos;
using DataPlatform.Shared.Repositories;
using Workflow.Billing.Domain.Entities;

namespace Billing.Domain.Entities
{
    public class PackageBillingTransaction<T> : ICommitBillingTransaction<PackageTransactionDto>
    {

        private readonly IRepository<StageBilling> _stageBillingRepository;

        public PackageBillingTransaction(IRepository<StageBilling> stageBillingRepository)
        {
            _stageBillingRepository = stageBillingRepository;
        }

        public void Commit(PackageTransactionDto entity)
        {
            var transactions = _stageBillingRepository.Where(x => x.Package.PackageId == entity.PackageId);

            foreach (var transactionRequest in transactions)
            {
                transactionRequest.Modified = DateTime.UtcNow;
                transactionRequest.ModifiedBy = "dev.billing.api.lightstone.co.za";

                transactionRequest.Package.PackageName = entity.PackageName;

                _stageBillingRepository.SaveOrUpdate(transactionRequest, true);
            }
        }
    }
}