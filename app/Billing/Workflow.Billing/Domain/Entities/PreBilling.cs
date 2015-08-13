
namespace Workflow.Billing.Domain.Entities
{
    public class PreBilling : BillingTransaction
    {
        public virtual int BillingId { get; set; }

        public PreBilling()
        {
        }
    }
}