using System;
using System.Collections.Generic;
using DataPlatform.Shared.Entities;
using PackageBuilder.Core.Events;

namespace PackageBuilder.Domain.Entities.Packages.Events
{
    public class PackageCreated : DomainEvent
    {
        public readonly string Name;
        public readonly string State;
        public readonly double CostOfSale;
        public readonly DateTime Created;
        public readonly DateTime Edited;
        public readonly string Owner;
        public readonly IEnumerable<IDataProvider> DataProviders;

        public PackageCreated(Guid id, string name, IEnumerable<IDataProvider> dataProviders)
        {
            Id = id;
            Name = name;
            State = null;
            CostOfSale = 0.00;
            Created = DateTime.Now;
            Owner = null;
            DataProviders = dataProviders;
        }
    }
}