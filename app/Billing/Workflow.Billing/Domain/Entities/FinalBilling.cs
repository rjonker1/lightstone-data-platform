using System;

namespace Workflow.Billing.Domain.Entities
{
    public class FinalBilling: BillingTransaction
    {
        public virtual int BillingId { get; set; }
        public virtual Guid StageBillingId { get; set; }

        public FinalBilling()
        {
        } 
    }
}