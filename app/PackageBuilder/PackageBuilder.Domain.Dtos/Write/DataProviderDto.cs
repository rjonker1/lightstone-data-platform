using System;
using System.Collections.Generic;
using System.Linq;

namespace PackageBuilder.Domain.Dtos.Write
{
    public class DataProviderDto
    {
        public DataProviderDto()
        {
            DataFields = Enumerable.Empty<DataProviderFieldItemDto>();
            RequestFields = Enumerable.Empty<DataProviderFieldItemDto>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal CostOfSale { get; set; }
        public bool SourceConfigurationIsApiConfiguration { get; set; }
        public string SourceConfigurationUrl { get; set; }
        public string SourceConfigurationUsername { get; set; }
        public string SourceConfigurationConnectionString { get; set; }
        public bool FieldLevelCostPriceOverride { get; set; }
        public bool RequiresConsent { get; set; }
        public string Owner { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? EditedDate { get; set; }
        public int Version { get; set; }
        public IEnumerable<DataProviderFieldItemDto> RequestFields { get; set; }
        public IEnumerable<DataProviderFieldItemDto> DataFields { get; set; }
    }
}