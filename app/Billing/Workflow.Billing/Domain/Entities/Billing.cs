using System;
using Shared.Messaging.Billing.Helpers;

namespace Workflow.Billing.Domain.Entities
{
    public class Billing : Entity
    {
        public virtual string Customer { get; set; }
        public Billing()
        {
            base.Id = Guid.NewGuid();
            base.Created = DateTime.UtcNow;
        }
    }
}