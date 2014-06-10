using System;
using EventTracking.Domain.Core;
using Monitoring.Consumer.Lace.Events;
using Monitoring.Sources;

namespace Monitoring.Consumer.Lace.Aggregates
{
    public class AggregateExternalSourcesHandled : AggregateBase
    {

        public AggregateExternalSourcesHandled(Guid id, Guid aggregateId, FromSource source, string message,
            DateTime eventDate)
            : this()
        {
            RaiseEvent(new ExternalSourceHandledEvent(id, aggregateId, source.ToString(), message, eventDate));
        }

        private AggregateExternalSourcesHandled()
        {
            Register<ExternalSourceHandledEvent>(e => Id = e.AggregateId);
        }
    }
}
