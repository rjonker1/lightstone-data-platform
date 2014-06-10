using System;

namespace EventTracking.Repository.Tests.Data
{
    public class EventTrackingTestAggregateCreated
    {
        public EventTrackingTestAggregateCreated(Guid aggregateId)
        {
            AggregateId = aggregateId;
        }

        public Guid AggregateId { get; private set; }
    }
}
