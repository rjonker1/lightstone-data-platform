using System;
using EventTracking.Domain.Core;
using Monitoring.Events.Lace;
using Monitoring.Sources.Lace;

namespace Monitoring.Consumer.Lace.Aggregates
{
    public class ExternalSourcesResponseFailures : AggregateBase
    {
        public ExternalSourcesResponseFailures(Guid id, Guid aggregateId, LaceEventSource source, string message,
            DateTime eventDate, string category)
            : this()
        {
            Category = category;
            RaiseEvent(new ExternalSourceResponseFailureEvent(id, aggregateId, (int)source, message,
                eventDate,category));
        }

        private ExternalSourcesResponseFailures()
        {
            Register<ExternalSourceResponseFailureEvent>(e => Id = e.AggregateId);
        }
    }
}
