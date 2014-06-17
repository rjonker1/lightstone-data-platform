using System;
using EventTracking.Domain.Core;
using Monitoring.Events.Lace;
using Monitoring.Sources.Lace;

namespace Monitoring.Consumer.Lace.Aggregates
{
    public class ExternalSourceFailures : AggregateBase
    {

        public ExternalSourceFailures(Guid id, Guid aggregateId, LaceEventSource source, string message, DateTime eventDate)
            : this()
        {
            RaiseEvent(new ExternalSourceFailedEvent(id, aggregateId, (int)source, message, eventDate));
        }

        private ExternalSourceFailures()
        {
            Register<ExternalSourceFailedEvent>(e => Id = e.AggregateId);
        }

    }

}
