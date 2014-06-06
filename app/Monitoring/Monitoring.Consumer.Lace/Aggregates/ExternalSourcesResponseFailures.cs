using System;
using EventTracking.Domain.Core;
using Monitoring.Events.Lace;
using Monitoring.Sources;

namespace Monitoring.Consumer.Lace.Aggregates
{
    public class ExternalSourcesResponseFailures : AggregateBase
    {
        public ExternalSourcesResponseFailures(Guid id, Guid aggregateId, FromSource source, string message,
            DateTime eventDate)
            : this()
        {
            RaiseEvent(new ExternalSourceResponseFailureEvent(id, aggregateId, source.ToString(), message,
                eventDate));
        }

        private ExternalSourcesResponseFailures()
        {
            Register<ExternalSourceResponseFailureEvent>(e => Id = e.AggregateId);
        }
    }
}
