using DataPlatform.Shared.Messaging.Billing.Helpers;

namespace Workflow.Billing.Domain.Entities
{
    public class AccountMeta : Entity
    {
        public virtual string AccountId { get; set; }

        public AccountMeta()
        {
        }
    }
}