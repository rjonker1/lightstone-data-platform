using System;
using System.Collections.Generic;

namespace Billing.Domain.Dtos
{
    public class PackageDto
    {
        public Guid PackageId { get; set; }
        public string PackageName { get; set; }
        public double PackageCostPrice { get; set; }
        public double PackageRecommendedPrice { get; set; }
        public IEnumerable<DataProviderDto> DataProviders { get; set; } 
    }
}