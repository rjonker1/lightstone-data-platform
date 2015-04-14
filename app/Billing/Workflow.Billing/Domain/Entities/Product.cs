using System;
using System.Collections;
using System.Collections.Generic;
using Shared.Messaging.Billing.Helpers;

namespace Workflow.Billing.Domain.Entities
{
    public class Product : Entity
    {
        public virtual string DataProviderName { get; set; }
        public virtual float CostPrice { get; set; }
        public virtual float RecommendedPrice { get; set; }

        public virtual Guid RequestId { get; set; }

        public Product() { }
    }
}