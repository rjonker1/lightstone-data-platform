using System;

namespace Workflow.Billing.Domain.Entities
{
    public interface IPackage
    {
        Guid PackageId { get; set; }
        string PackageName { get; set; }
        double PackageCostPrice { get; set; }
        double PackageRecommendedPrice { get; set; }
    }

    public class Package : IPackage //: DataProvider
    {
        public virtual Guid PackageId { get; set; }
        public virtual string PackageName { get; set; }
        public virtual double PackageCostPrice { get; set; }
        public virtual double PackageRecommendedPrice { get; set; }
    }
}