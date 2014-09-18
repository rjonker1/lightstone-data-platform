using System;
using PackageBuilder.Domain.Helpers.Cqrs.Events;

namespace PackageBuilder.Domain.DataFields.Events
{
    public class DataFieldRenamed : DomainEvent
    {
        public readonly string NewName;
        public DataFieldRenamed(Guid id, string name)
        {
            Id = id;
            NewName = name;
        }
    }
}