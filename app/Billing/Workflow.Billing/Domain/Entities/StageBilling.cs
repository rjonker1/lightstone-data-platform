namespace Workflow.Billing.Domain.Entities
{
    public class StageBilling : User
    {
        public virtual int BillingId { get; set; }

        public StageBilling()
        {
        } 
    }
}