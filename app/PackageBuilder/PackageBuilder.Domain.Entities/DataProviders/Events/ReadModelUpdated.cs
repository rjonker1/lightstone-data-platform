using System;
using PackageBuilder.Core.Events;

namespace PackageBuilder.Domain.Entities.DataProviders.Events
{
    public class ReadModelUpdated : DomainEvent
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public int Version { get; private set; }

        public ReadModelUpdated(Guid id, string name, int version)
        {
            Id = id;
            Name = name;
            Version = version;
        }
    }
}
