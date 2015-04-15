using System;
using System.Collections;
using System.Collections.Generic;
using Shared.Messaging.Billing.Helpers;

namespace Workflow.Billing.Domain.Entities
{
    public class Product : BillingTransaction//: Entity
    {
        public virtual Guid ProductId { get; set; }
        public virtual string ProductName { get; set; }
        public virtual double CostPrice { get; set; }
        public virtual double RecommendedPrice { get; set; }

        public virtual Guid RequestId { get; set; }

        public Product() { }
    }
}