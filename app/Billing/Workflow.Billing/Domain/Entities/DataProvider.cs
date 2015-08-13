using System;

namespace Workflow.Billing.Domain.Entities
{
    public class DataProvider
    {
        public virtual Guid DataProviderId { get; set; }
        public virtual string DataProviderName { get; set; }
        public virtual double CostPrice { get; set; }
        public virtual double RecommendedPrice { get; set; }

        public DataProvider() { }
    }
}