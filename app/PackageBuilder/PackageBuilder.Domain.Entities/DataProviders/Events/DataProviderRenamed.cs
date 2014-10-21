using System;
using PackageBuilder.Core.Events;

namespace PackageBuilder.Domain.Entities.DataProviders.Events
{
    public class DataProviderRenamed : DomainEvent
    {
        public readonly string NewName;
        public DataProviderRenamed(Guid id, string name)
        {
            Id = id;
            NewName = name;
        }
    }
}