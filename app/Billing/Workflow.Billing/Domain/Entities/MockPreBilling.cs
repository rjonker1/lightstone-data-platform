namespace Workflow.Billing.Domain.Entities
{
    public class MockPreBilling : Billing
    {
        public virtual int BillingId { get; set; }

        public MockPreBilling()
        {
        }
    }
}