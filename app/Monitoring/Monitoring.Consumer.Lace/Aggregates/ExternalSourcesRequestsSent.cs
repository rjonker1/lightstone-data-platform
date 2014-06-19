using System;
using EventTracking.Domain.Core;
using Monitoring.Events.Lace;
using Monitoring.Sources.Lace;

namespace Monitoring.Consumer.Lace.Aggregates
{
    public class ExternalSourcesRequestsSent : AggregateBase
    {

        public ExternalSourcesRequestsSent(Guid id, Guid aggregateId, LaceEventSource source, string message,
            DateTime eventDate, string payload, string category)
            : this()
        {
            Category = category;
            RaiseEvent(new ExternalSourceRequestSentEvent(id, aggregateId, (int)source, message,
                eventDate, payload,category));
        }

        private ExternalSourcesRequestsSent()
        {
            Register<ExternalSourceRequestSentEvent>(e => Id = e.AggregateId);
        }
    }
}
