using System;

namespace PackageBuilder.Domain.DataProviders.ReadModels
{
    public class DataProviderReadModel
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public int Version { get; set; }
    }
}