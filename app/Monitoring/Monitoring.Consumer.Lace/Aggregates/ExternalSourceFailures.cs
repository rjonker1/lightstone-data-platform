using System;
using EventTracking.Domain.Core;
using Monitoring.Events.Lace;
using Monitoring.Sources;

namespace Monitoring.Consumer.Lace.Aggregates
{
    public class ExternalSourceFailures : AggregateBase
    {

        public ExternalSourceFailures(Guid id, Guid aggregateId, FromSource source, string message, DateTime eventDate)
            : this()
        {
            RaiseEvent(new ExternalSourceFailedEvent(id, aggregateId, source.ToString(), message, eventDate));
        }

        private ExternalSourceFailures()
        {
            Register<ExternalSourceFailedEvent>(e => Id = e.AggregateId);
        }

    }

}
