using System;
using Raven.Client;

namespace PackageBuilder.Domain.DataProviders.ReadModels
{
    public class DataProviderReadModel
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public int Version { get; set; }

    }
}