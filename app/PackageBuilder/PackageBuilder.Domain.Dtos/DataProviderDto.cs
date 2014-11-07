using System;
using System.Collections.Generic;
using DataPlatform.Shared.Enums;

namespace PackageBuilder.Domain.Dtos
{
    public class DataProviderDto
    {
        public Guid Id { get; set; }
        public DataProviderName Name { get; set; }
        public double CostOfSale { get; set; }
        public string Owner { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }

        public int Version { get; set; }

        public int incVersion()
        {
            return Version++;
        }

        public IEnumerable<DataProviderFieldItemDto> DataFields { get; set; }
    }
}