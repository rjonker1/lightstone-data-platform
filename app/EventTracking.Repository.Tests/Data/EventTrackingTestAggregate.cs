using System;
using EventTracking.Domain.Core;
using EventTracking.Repository.Tests.Events;

namespace EventTracking.Repository.Tests.Data
{
    public class EventTrackingTestAggregate : AggregateBase
    {
        public EventTrackingTestAggregate(Guid aggregateId) : this()
        {
            RaiseEvent(new EventTrackingTestAggregateCreated(aggregateId));
        }

        private EventTrackingTestAggregate()
        {
            Register<EventTrackingTestAggregateCreated>(e => Id = e.AggregateId);
            Register<ExternalSourceEvent>(e => AppliedEventCount++);
        }

        public int AppliedEventCount { get; private set; }

        public void ProduceEvents(int count)
        {
            for (var i = 0; i < count; i++)
                RaiseEvent(new ExternalSourceEvent("External Source 1-" + i, "External Source 2-" + i));
        }
    }
}
