using DataPlatform.Shared.Repositories;
using Workflow.Billing.Domain.Entities;

namespace Billing.Domain.Entities
{
    public class UpdateBillingTransaction
    {
        private readonly IRepository<StageBilling> _stageBillingRepository;

        public UpdateBillingTransaction(IRepository<StageBilling> stageBillingRepository)
        {
            _stageBillingRepository = stageBillingRepository;
        }

        public void Commit()
        {
            //foreach (var userTransaction in body.Transactions)
            //{

            //}
        }
    }
}