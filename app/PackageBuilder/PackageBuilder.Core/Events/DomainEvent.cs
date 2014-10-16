using System;

namespace PackageBuilder.Core.Events
{
    public class DomainEvent : IDomainEvent
    {
        public Guid Id;
        public int Version;
    }
}
