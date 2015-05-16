using System.Collections.Generic;
using System.Linq;
using PackageBuilder.Domain.Entities.Industries.Read;

namespace PackageBuilder.Domain.Dtos.Write
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
        public double CostOfSale { get; set; }
        public bool? IsSelected { get; set; }
        public int Order { get; set; }
        public IEnumerable<DataProviderFieldItemDto> RequestFields { get; set; }
        public IEnumerable<DataProviderFieldItemDto> DataFields { get; set; }
    }
}