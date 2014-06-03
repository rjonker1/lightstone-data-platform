using System;
using EventTracking.Domain.Core;
using Monitoring.Modules.Lace.AggregateEvents;
using Monitoring.Sources;

namespace Monitoring.Modules.Lace.Aggregates
{
    public class AggregateExternalSourcesResponseSuccesses : AggregateBase
    {

        public AggregateExternalSourcesResponseSuccesses(Guid id, Guid aggregateId, FromSource source, string message,
            DateTime eventDate)
            : this()
        {
            RaiseEvent(new AggregateExternalSourceResponseSuccessEvent(id, aggregateId, source.ToString(), message,
                eventDate));
        }

        private AggregateExternalSourcesResponseSuccesses()
        {
            Register<AggregateExternalSourceResponseSuccessEvent>(e => Id = e.AggregateId);
        }
    }
}
