using System;
using Shared.Messaging.Billing.Helpers;

namespace Workflow.Billing.Domain.Entities
{
    public class BillingTransaction : Entity
    {
        public virtual Guid CustomerId { get; set; }
        public virtual string CustomerName { get; set; }
        public virtual Guid ClientId { get; set; }
        public virtual string ClientName { get; set; }

        public virtual string AccountNumber { get; set; }

        public BillingTransaction() { }
    }
}