using System;

namespace PackageBuilder.Core.Helpers.Cqrs.Events
{
    public class DomainEvent : IDomainEvent
    {
        public Guid Id;
        public int Version;
    }
}
