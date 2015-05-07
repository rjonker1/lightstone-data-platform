using DataPlatform.Shared.Messaging.Billing.Helpers;

namespace Workflow.Billing.Domain.Entities
{
    public class AccountMeta : Entity
    {
        public virtual string AccountNumber { get; set; }
        public virtual string BillingType { get; set; }

        public AccountMeta()
        {
        }
    }
}