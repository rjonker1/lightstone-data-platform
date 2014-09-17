using System;
using PackageBuilder.Domain.Helpers.Cqrs.Events;

namespace PackageBuilder.Domain.DataProviders.Events
{
    public class DataProviderRenamedEvent : Event
    {
        public readonly string NewName;
        public DataProviderRenamedEvent(Guid id, string name)
        {
            Id = id;
            NewName = name;
        }
    }
}