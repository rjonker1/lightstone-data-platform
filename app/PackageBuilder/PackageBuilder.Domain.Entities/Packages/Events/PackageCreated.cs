using System;
using System.Collections.Generic;
using DataPlatform.Shared.Entities;
using PackageBuilder.Core.Events;

namespace PackageBuilder.Domain.Entities.Packages.Events
{
    public class PackageCreated : DomainEvent
    {
        public readonly string Name;
        public readonly IEnumerable<IDataProvider> DataProviders;

        public PackageCreated(Guid id, string name, IEnumerable<IDataProvider> dataProviders)
        {
            Id = id;
            Name = name;
            DataProviders = dataProviders;
        }
    }
}