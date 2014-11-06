using System;
using System.Collections.Generic;

namespace PackageBuilder.Domain.Dtos
{
    public class DataProviderDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double CostOfSale { get; set; }
        public string Owner { get; set; }
        public string State { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? EditedDate { get; set; }

        public int Version { get; set; }

        public int incVersion()
        {
            return Version++;
        }

        public IEnumerable<DataProviderFieldItemDto> DataFields { get; set; }
    }
}