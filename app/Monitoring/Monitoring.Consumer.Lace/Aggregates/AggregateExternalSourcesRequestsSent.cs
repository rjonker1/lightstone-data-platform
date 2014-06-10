using System;
using EventTracking.Domain.Core;
using Monitoring.Consumer.Lace.Events;
using Monitoring.Sources;

namespace Monitoring.Consumer.Lace.Aggregates
{
    public class AggregateExternalSourcesRequestsSent : AggregateBase
    {

        public AggregateExternalSourcesRequestsSent(Guid id, Guid aggregateId, FromSource source, string message,
            DateTime eventDate)
            : this()
        {
            RaiseEvent(new ExternalSourceRequestSentEvent(id, aggregateId, source.ToString(), message,
                eventDate));
        }

        private AggregateExternalSourcesRequestsSent()
        {
            Register<ExternalSourceRequestSentEvent>(e => Id = e.AggregateId);
        }
    }
}
