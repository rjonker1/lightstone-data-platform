using System;
using EventTracking.Domain.Core;
using Monitoring.Modules.Lace.AggregateEvents;
using Monitoring.Sources;

namespace Monitoring.Modules.Lace.Aggregates
{
    public class AggregateExternalSourcesRequestsSent : AggregateBase
    {

        public AggregateExternalSourcesRequestsSent(Guid id, Guid aggregateId, FromSource source, string message,
            DateTime eventDate)
            : this()
        {
            RaiseEvent(new AggregateExternalSourceRequestSentEvent(id, aggregateId, source.ToString(), message,
                eventDate));
        }

        private AggregateExternalSourcesRequestsSent()
        {
            Register<AggregateExternalSourceRequestSentEvent>(e => Id = e.AggregateId);
        }
    }
}
