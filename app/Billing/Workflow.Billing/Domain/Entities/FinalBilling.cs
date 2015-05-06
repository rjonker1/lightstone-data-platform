using System;

namespace Workflow.Billing.Domain.Entities
{
    public class FinalBilling: User
    {
        public virtual int BillingId { get; set; }
        public virtual Guid StageBillingId { get; set; }

        public FinalBilling()
        {
        } 
    }
}