using System;
using EventTracking.Domain.Core;
using Monitoring.Consumer.Lace.Events;
using Monitoring.Sources;

namespace Monitoring.Consumer.Lace.Aggregates
{
    public class AggregateExternalSourcesResponseFailures : AggregateBase
    {
        public AggregateExternalSourcesResponseFailures(Guid id, Guid aggregateId, FromSource source, string message,
            DateTime eventDate)
            : this()
        {
            RaiseEvent(new ExternalSourceResponseFailureEvent(id, aggregateId, source.ToString(), message,
                eventDate));
        }

        private AggregateExternalSourcesResponseFailures()
        {
            Register<ExternalSourceResponseFailureEvent>(e => Id = e.AggregateId);
        }
    }
}
