
namespace Workflow.Billing.Domain.Entities
{
    public class PreBilling : User
    {
        public virtual int BillingId { get; set; }

        public PreBilling()
        {
        }
    }
}