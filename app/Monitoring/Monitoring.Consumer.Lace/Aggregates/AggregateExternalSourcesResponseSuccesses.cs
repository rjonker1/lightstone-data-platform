using System;
using EventTracking.Domain.Core;
using Monitoring.Consumer.Lace.Events;
using Monitoring.Sources;

namespace Monitoring.Consumer.Lace.Aggregates
{
    public class AggregateExternalSourcesResponseSuccesses : AggregateBase
    {

        public AggregateExternalSourcesResponseSuccesses(Guid id, Guid aggregateId, FromSource source, string message,
            DateTime eventDate)
            : this()
        {
            RaiseEvent(new ExternalSourceResponseSuccessEvent(id, aggregateId, source.ToString(), message,
                eventDate));
        }

        private AggregateExternalSourcesResponseSuccesses()
        {
            Register<ExternalSourceResponseSuccessEvent>(e => Id = e.AggregateId);
        }
    }
}
