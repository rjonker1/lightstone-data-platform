using System;
using System.Collections.Generic;
using Shared.Messaging.Billing.Helpers;

namespace Workflow.Billing.Domain.Entities
{
    public class PreBilling : Entity
    {
        public virtual IEnumerable<UserMeta> Users { get; set; }

        public PreBilling()
        {
            base.Id = Guid.NewGuid();
        }
    }
}