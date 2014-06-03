using System;
using EventTracking.Domain.Core;
using Monitoring.Modules.Lace.AggregateEvents;
using Monitoring.Sources;

namespace Monitoring.Modules.Lace.Aggregates
{
    public class AggregateExternalSourcesResponseFailures : AggregateBase
    {
        public AggregateExternalSourcesResponseFailures(Guid id, Guid aggregateId, FromSource source, string message,
            DateTime eventDate)
            : this()
        {
            RaiseEvent(new AggregateExternalSourceResponseFailureEvent(id, aggregateId, source.ToString(), message,
                eventDate));
        }

        private AggregateExternalSourcesResponseFailures()
        {
            Register<AggregateExternalSourceResponseFailureEvent>(e => Id = e.AggregateId);
        }
    }
}
