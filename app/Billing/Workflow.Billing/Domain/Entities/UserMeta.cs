using Shared.Messaging.Billing.Helpers;

namespace Workflow.Billing.Domain.Entities
{
    public class UserMeta : Entity
    {
        public virtual string Username { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }

        public UserMeta() { }
    }
}