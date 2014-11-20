﻿using System.Collections.Generic;
using System.Linq;

namespace PackageBuilder.Domain.Dtos
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
        public string Industry { get; set; }
        public double Price { get; set; }
        public bool? IsSelected { get; set; }
        public IEnumerable<DataProviderFieldItemDto> DataFields { get; set; }
    }
}