using System;
using EventTracking.Domain.Core;
using Monitoring.Modules.Lace.AggregateEvents;
using Monitoring.Sources;

namespace Monitoring.Modules.Lace.Aggregates
{
    public class AggregateExternalSourceFailures : AggregateBase
    {

        public AggregateExternalSourceFailures(Guid id, Guid aggregateId, FromSource source, string message, DateTime eventDate)
            : this()
        {
            RaiseEvent(new AggregateExternalSourceFailedEvent(id, aggregateId, source.ToString(), message, eventDate));
        }

        private AggregateExternalSourceFailures()
        {
            Register<AggregateExternalSourceFailedEvent>(e => Id = e.AggregateId);
        }

    }

}
