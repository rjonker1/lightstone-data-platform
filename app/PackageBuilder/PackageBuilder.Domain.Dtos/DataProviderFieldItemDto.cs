using System;

namespace PackageBuilder.Domain.Dtos
{
    public class DataProviderFieldItemDto
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Label { get; set; }
        public string Definition { get; set; }
        public string Industries { get; set; }
        public double Price { get; set; }
        public bool IsSelected { get; set; }
    }
}