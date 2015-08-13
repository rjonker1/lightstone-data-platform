using System;
using DataPlatform.Shared.Messaging.Billing.Helpers;

namespace Workflow.Billing.Domain.Entities
{
    public class BillingTransaction : Entity
    {
        public virtual Guid CustomerId { get; set; }
        public virtual string CustomerName { get; set; }
        public virtual Guid ClientId { get; set; }
        public virtual string ClientName { get; set; }

        public virtual string AccountNumber { get; set; }
        public virtual string BillingType { get; set; }
        public virtual Guid ContractId { get; set; }

        public virtual Guid PackageId { get; set; }
        public virtual string PackageName { get; set; }
        public virtual double PackageCostPrice { get; set; }
        public virtual double PackageRecommendedPrice { get; set; }

        public virtual Guid DataProviderId { get; set; }
        public virtual string DataProviderName { get; set; }
        public virtual double CostPrice { get; set; }
        public virtual double RecommendedPrice { get; set; }

        public virtual Guid TransactionId { get; set; }
        public virtual Guid RequestId { get; set; }
        public virtual bool IsBillable { get; set; }

        public virtual Guid UserId { get; set; }
        public virtual string Username { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }

        public virtual bool HasTransactions { get; set; }

        public BillingTransaction()
        {
            Created = DateTime.UtcNow;
        }
    }
}