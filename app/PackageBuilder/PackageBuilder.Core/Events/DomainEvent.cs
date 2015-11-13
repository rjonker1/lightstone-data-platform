using System;
using PackageBuilder.Domain.Core.Contracts.Events;

namespace PackageBuilder.Core.Events
{
    public class DomainEvent : IDomainEvent
    {
        public Guid Id;
        public int Version;
    }
}
