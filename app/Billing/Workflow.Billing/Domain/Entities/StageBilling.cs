using System;

namespace Workflow.Billing.Domain.Entities
{
    public class StageBilling : BillingTransaction
    {
        public virtual int BillingId { get; set; }
        public virtual Guid PreBillingId { get; set; }

        public StageBilling()
        {
        } 
    }
}