using System;
using System.Collections.Generic;
using Shared.Messaging.Billing.Helpers;

namespace Workflow.Billing.Domain.Entities
{
    public class PreBilling : User//: Entity
    {
        public virtual int BillingId { get; set; }

        public PreBilling()
        {
        }
    }
}