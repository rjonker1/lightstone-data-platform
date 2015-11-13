using System;

namespace Billing.Domain.Dtos
{
    public class DataProviderDto
    {
        public Guid DataProviderId { get; set; }
        public string DataProviderName { get; set; }
        public double CostPrice { get; set; }
        public double RecommendedPrice { get; set; }

        public Guid PackageId { get; set; }
        public string PackageName { get; set; } 
    }
}