using System;
using System.Collections.Generic;

namespace Workflow.Billing.Domain.Dtos
{
    public class PackageDto
    {
        public Guid PackageId { get; set; }
        public DateTime? Created { get; set; }
        public string PackageName { get; set; }
        public string PackageDescription { get; set; }
        public double PackageCostPrice { get; set; }
        public double PackageRecommendedPrice { get; set; }
        public int PackageTransactions { get; set; }
    }
}