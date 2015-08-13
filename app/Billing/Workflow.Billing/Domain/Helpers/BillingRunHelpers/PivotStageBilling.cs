using System.Linq;
using AutoMapper;
using DataPlatform.Shared.Repositories;
using Workflow.Billing.Domain.Entities;

namespace Workflow.Billing.Domain.Helpers.BillingRunHelpers
{
    public class PivotStageBilling : IPivotBilling<PivotStageBilling>
    {
        private readonly IRepository<PreBilling> _preBillingrRepository;
        private readonly IRepository<StageBilling> _stageBillingRepository;

        public PivotStageBilling(IRepository<PreBilling> preBillingrRepository, IRepository<StageBilling> stageBillingRepository)
        {
            _preBillingrRepository = preBillingrRepository;
            _stageBillingRepository = stageBillingRepository;
        }

        public void Pivot()
        {
            foreach (var preBilling in _preBillingrRepository)
            {
                var stageEntity = Mapper.Map(preBilling, new StageBilling());

                // Check if transaction has already been recorded
                if (!_stageBillingRepository.Any(x => x.PreBillingId == stageEntity.PreBillingId))
                {
                    // Internal transactions - non-billable
                    if (stageEntity.BillingType.Contains("INTERNAL"))
                        stageEntity.UserTransaction.IsBillable = false;

                    _stageBillingRepository.SaveOrUpdate(stageEntity, true);
                }
            }
        }
    }
}