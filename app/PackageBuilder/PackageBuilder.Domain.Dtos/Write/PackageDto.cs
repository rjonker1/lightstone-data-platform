using System;
using System.Collections.Generic;
using DataPlatform.Shared.Enums;
using PackageBuilder.Domain.Entities.States.Read;

namespace PackageBuilder.Domain.Dtos.Write
{
    public class PackageDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public PackageEventType PackageEventType { get; set; }
        public IEnumerable<IndustryDto> Industries { get; set; }
        public int Version { get; set; }
        public decimal DisplayVersion { get; set; }
        public State State { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EditedDate { get; set; }
        public string Owner { get; set; }
        public decimal CostOfSale { get; set; }
        public decimal RecommendedSalePrice { get; set; }
        public IEnumerable<DataProviderDto> DataProviders { get; set; }
    }
}