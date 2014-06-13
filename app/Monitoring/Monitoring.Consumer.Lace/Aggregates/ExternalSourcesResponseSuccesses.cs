using System;
using EventTracking.Domain.Core;
using Monitoring.Events.Lace;
using Monitoring.Sources.Lace;

namespace Monitoring.Consumer.Lace.Aggregates
{
    public class ExternalSourcesResponseSuccesses : AggregateBase
    {

        public ExternalSourcesResponseSuccesses(Guid id, Guid aggregateId, LaceEventSource source, string message,
            DateTime eventDate,string payload)
            : this()
        {
            RaiseEvent(new ExternalSourceResponseSuccessEvent(id, aggregateId, (int)source, message,
                eventDate, payload));
        }

        private ExternalSourcesResponseSuccesses()
        {
            Register<ExternalSourceResponseSuccessEvent>(e => Id = e.AggregateId);
        }
    }
}
