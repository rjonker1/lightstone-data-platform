using System;
using PackageBuilder.Domain.Helpers.Cqrs.Events;

namespace PackageBuilder.Domain.DataProviders.Events
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