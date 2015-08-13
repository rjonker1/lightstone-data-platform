using System;
using DataPlatform.Shared.Messaging.Billing.Helpers;

namespace Workflow.Billing.Domain.Entities
{
    public interface IDataProvider
    {
        Guid DataProviderId { get; set; }
        string DataProviderName { get; set; }
        double CostPrice { get; set; }
        double RecommendedPrice { get; set; }
    }

    public class DataProvider : IDataProvider //: BillingTransaction
    {
        public virtual Guid DataProviderId { get; set; }
        public virtual string DataProviderName { get; set; }
        public virtual double CostPrice { get; set; }
        public virtual double RecommendedPrice { get; set; }

        public DataProvider() { }
    }
}