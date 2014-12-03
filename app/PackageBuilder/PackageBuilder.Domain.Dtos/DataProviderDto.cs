using System;
using System.Collections.Generic;
using System.Linq;

namespace PackageBuilder.Domain.Dtos
{
    public class DataProviderDto
    {
        public DataProviderDto()
        {
            DataFields = Enumerable.Empty<DataProviderFieldItemDto>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double CostOfSale { get; set; }
        public string SourceURL { get; set; }
        public bool FieldLevelCostPriceOverride { get; set; }
        public string Owner { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? EditedDate { get; set; }
        public int Version { get; set; }
        public IEnumerable<DataProviderFieldItemDto> DataFields { get; set; }
    }
}