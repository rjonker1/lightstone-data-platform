using System;
using EventTracking.Domain.Core;
using Monitoring.Events.Lace;
using Monitoring.Sources;

namespace Monitoring.Consumer.Lace.Aggregates
{
    public class ExternalSourcesResponseSuccesses : AggregateBase
    {

        public ExternalSourcesResponseSuccesses(Guid id, Guid aggregateId, FromSource source, string message,
            DateTime eventDate,string payload)
            : this()
        {
            RaiseEvent(new ExternalSourceResponseSuccessEvent(id, aggregateId, source.ToString(), message,
                eventDate, payload));
        }

        private ExternalSourcesResponseSuccesses()
        {
            Register<ExternalSourceResponseSuccessEvent>(e => Id = e.AggregateId);
        }
    }
}
