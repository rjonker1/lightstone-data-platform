using System;

namespace PackageBuilder.Domain.Helpers.Cqrs.Events
{
    public class DomainEvent : IDomainEvent
    {
        public Guid Id; 
    }
}