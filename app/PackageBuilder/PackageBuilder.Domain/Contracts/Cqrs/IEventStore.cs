using System;
using System.Collections.Generic;
using PackageBuilder.Domain.Events;

namespace PackageBuilder.Domain.Contracts.Cqrs
{
    public interface IEventStore
    {
        void SaveEvents(Guid aggregateId, IEnumerable<Event> events, int expectedVersion);
        List<Event> GetEventsForAggregate(Guid aggregateId);
    }
}