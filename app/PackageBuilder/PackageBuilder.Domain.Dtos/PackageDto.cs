using System;
using System.Collections.Generic;

namespace PackageBuilder.Domain.Dtos
{
    public class PackageDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
        public int Version { get; set; }
        public decimal DisplayVersion { get; set; }
        public string Industry { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EditedDate { get; set; }
        public string Owner { get; set; }
        public double CostOfSale { get; set; }
        public double RecommendedSalePrice { get; set; }
        public IEnumerable<DataProviderDto> DataProviders { get; set; }
    }
}