using System;

namespace Workflow.Billing.Domain.Entities
{
    public class Customer : AccountMeta
    {
        public virtual Guid CustomerId { get; set; }
        public virtual string CustomerName { get; set; }

        public Customer()
        {
        }
    }
}