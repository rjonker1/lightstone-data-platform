namespace Workflow.Billing.Domain.Entities
{
    public class MockPreBilling : User
    {
        public virtual int BillingId { get; set; }

        public MockPreBilling()
        {
        }
    }
}