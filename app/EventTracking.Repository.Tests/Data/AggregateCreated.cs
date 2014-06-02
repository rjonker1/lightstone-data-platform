using System;

namespace EventTracking.Repository.Tests.Data
{
    public class AggregateCreated
    {
        public AggregateCreated(Guid aggregateId)
        {
            AggregateId = aggregateId;
        }

        public Guid AggregateId { get; private set; }
    }
}
