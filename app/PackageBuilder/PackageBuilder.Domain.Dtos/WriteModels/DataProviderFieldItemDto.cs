using System.Collections.Generic;
using System.Linq;
using PackageBuilder.Domain.Entities.Industries.WriteModels;

namespace PackageBuilder.Domain.Dtos.WriteModels
{
    public class DataProviderFieldItemDto
    {
        public DataProviderFieldItemDto()
        {
            DataFields = Enumerable.Empty<DataProviderFieldItemDto>();
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public string Label { get; set; }
        public string Definition { get; set; }
        public IEnumerable<Industry> Industries { get; set; }
        // todo: change to CostOfSale
        public double Price { get; set; }
        public bool? IsSelected { get; set; }
        public IEnumerable<DataProviderFieldItemDto> DataFields { get; set; }
    }
}