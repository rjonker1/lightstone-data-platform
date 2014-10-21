using System;
using System.Collections.Generic;
using CommonDomain.Core;
using DataPlatform.Shared.Entities;
using PackageBuilder.Domain.Entities.Packages.Events;

namespace PackageBuilder.Domain.Entities.Packages.WriteModels
{
    public class Package : AggregateBase
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Owner { get; private set; }
        public DateTime Created { get; private set; }
        public DateTime Edited { get; private set; }
        public int Version { get; private set; }
        public IEnumerable<IDataProvider> DataProviders { get; private set; }
        protected Package() { }

        public Package(Guid id, string name, string description, string owner, IEnumerable<IDataProvider> dataProviders)
        {
            RaiseEvent(new PackageCreated(id, name, dataProviders));
        }

        private void Apply(PackageCreated @event)
        {
            Id = @event.Id;
            Name = @event.Name;
            DataProviders = @event.DataProviders;
        }
    }
}
