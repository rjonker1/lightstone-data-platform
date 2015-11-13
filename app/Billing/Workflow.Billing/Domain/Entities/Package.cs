using System;

namespace Workflow.Billing.Domain.Entities
{
    public class Package
    {
        public virtual Guid PackageId { get; set; }
        public virtual string PackageName { get; set; }
        public virtual double PackageCostPrice { get; set; }
        public virtual double PackageRecommendedPrice { get; set; }
    }
}