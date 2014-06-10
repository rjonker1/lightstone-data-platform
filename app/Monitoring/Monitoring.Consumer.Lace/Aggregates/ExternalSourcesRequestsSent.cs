using System;
using EventTracking.Domain.Core;
using Monitoring.Events.Lace;
using Monitoring.Sources;

namespace Monitoring.Consumer.Lace.Aggregates
{
    public class ExternalSourcesRequestsSent : AggregateBase
    {

        public ExternalSourcesRequestsSent(Guid id, Guid aggregateId, FromSource source, string message,
            DateTime eventDate, string payload)
            : this()
        {
            RaiseEvent(new ExternalSourceRequestSentEvent(id, aggregateId, source.ToString(), message,
                eventDate, payload));
        }

        private ExternalSourcesRequestsSent()
        {
            Register<ExternalSourceRequestSentEvent>(e => Id = e.AggregateId);
        }
    }
}
