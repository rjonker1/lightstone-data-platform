using System;
using EventTracking.Domain.Core;
using Monitoring.Modules.Lace.AggregateEvents;
using Monitoring.Sources;

namespace Monitoring.Modules.Lace.Aggregates
{
    public class ExternalServiceFailedAggregate : AggregateBase
    {
        public ExternalServiceFailedAggregate(Guid aggregateId) : this()
        {
            RaiseEvent(new ExternalSourceAggregateCreated(aggregateId));
        }

        private ExternalServiceFailedAggregate()
        {
            Register<ExternalSourceAggregateCreated>(e => Id = e.AggregateId);
            Register<ExternalSourceFailedEvent>(e => AppliedEventCount++);
        }

        public int AppliedEventCount { get; private set; }

        public void ProduceEvent(Guid id, FromSource source, string message, DateTime eventDate)
        {
            RaiseEvent(new ExternalSourceFailedEvent(id, source, message, eventDate));
        }
    }
}
