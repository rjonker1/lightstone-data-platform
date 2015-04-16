using System;
using System.Collections;
using System.Collections.Generic;
using Shared.Messaging.Billing.Helpers;

namespace Workflow.Billing.Domain.Entities
{
    public class DataProvider : BillingTransaction
    {
        public virtual Guid DataProviderId { get; set; }
        public virtual string DataProviderName { get; set; }
        public virtual double CostPrice { get; set; }
        public virtual double RecommendedPrice { get; set; }

        public DataProvider() { }
    }
}