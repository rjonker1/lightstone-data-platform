using System;
using EventTracking.Domain.Core;
using EventTracking.Repository.Tests.Events;

namespace EventTracking.Repository.Tests.Data
{
    public class Aggregate : AggregateBase
    {
         public Aggregate(Guid aggregateId) : this()
        {
            RaiseEvent(new AggregateCreated(aggregateId));
        }

         private Aggregate()
        {
            Register<AggregateCreated>(e => Id = e.AggregateId);
            Register<ExternalSourceEvent>(e => AppliedEventCount++);
        }

        public int AppliedEventCount { get; private set; }

        public void ProduceEvents(int count)
        {
            for (int i = 0; i < count; i++)
                RaiseEvent(new ExternalSourceEvent("External Source 1-" + i, "External Source 2-" + i));
        }
    }
}
