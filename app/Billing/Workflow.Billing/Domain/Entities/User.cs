using System;

namespace Workflow.Billing.Domain.Entities
{
    public class User
    {
        public virtual Guid UserId { get; set; }
        public virtual string Username { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }

        public virtual bool HasTransactions { get; set; }

        public User() { }
    }
}