using System;
using System.Linq;
using Billing.Domain.Dtos;
using DataPlatform.Shared.Repositories;
using Workflow.Billing.Domain.Entities;

namespace Billing.Domain.Entities
{
    public class CustomerClientBillingTransaction<T> : ICommitBillingTransaction<CustomerClientTransactionDto>
    {

        private readonly IRepository<StageBilling> _stageBillingRepository;

        public CustomerClientBillingTransaction(IRepository<StageBilling> stageBillingRepository)
        {
            _stageBillingRepository = stageBillingRepository;
        }

        public void Commit(CustomerClientTransactionDto entity)
        {

            var transactions = _stageBillingRepository.Where(x => x.CustomerId == entity.Id || x.ClientId == entity.Id);

            foreach (var transactionRequest in transactions)
            {
                transactionRequest.Modified = DateTime.UtcNow;
                transactionRequest.ModifiedBy = "dev.billing.api.lightstone.co.za";

                transactionRequest.CustomerName = entity.Value;

                _stageBillingRepository.SaveOrUpdate(transactionRequest);
            }

        }
    }
}