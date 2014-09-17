using System;

namespace PackageBuilder.Domain.Helpers.Cqrs.Events
{
    public class Event : IDomainEvent
    {
        public Guid Id; 
        public int Version;
    }
}