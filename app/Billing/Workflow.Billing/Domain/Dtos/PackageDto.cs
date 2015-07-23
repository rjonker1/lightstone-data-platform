using System;

namespace Workflow.Billing.Domain.Dtos
{
    public class PackageDto
    {
        public Guid PackageId { get; set; }
        public string PackageName { get; set; }
        public double PackageCostPrice { get; set; }
        public double PackageRecommendedPrice { get; set; }
    }
}