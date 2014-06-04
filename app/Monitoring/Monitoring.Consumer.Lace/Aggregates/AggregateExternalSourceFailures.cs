using System;
using EventTracking.Domain.Core;
using Monitoring.Consumer.Lace.Events;
using Monitoring.Sources;

namespace Monitoring.Consumer.Lace.Aggregates
{
    public class AggregateExternalSourceFailures : AggregateBase
    {

        public AggregateExternalSourceFailures(Guid id, Guid aggregateId, FromSource source, string message, DateTime eventDate)
            : this()
        {
            RaiseEvent(new ExternalSourceFailedEvent(id, aggregateId, source.ToString(), message, eventDate));
        }

        private AggregateExternalSourceFailures()
        {
            Register<ExternalSourceFailedEvent>(e => Id = e.AggregateId);
        }

    }

}
