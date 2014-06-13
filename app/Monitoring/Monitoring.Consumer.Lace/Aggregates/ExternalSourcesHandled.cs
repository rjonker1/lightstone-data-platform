using System;
using EventTracking.Domain.Core;
using Monitoring.Events.Lace;
using Monitoring.Sources.Lace;

namespace Monitoring.Consumer.Lace.Aggregates
{
    public class ExternalSourcesHandled : AggregateBase
    {

        public ExternalSourcesHandled(Guid id, Guid aggregateId, LaceEventSource source, string message,
            DateTime eventDate)
            : this()
        {
            RaiseEvent(new ExternalSourceHandledEvent(id, aggregateId, (int)source, message, eventDate));
        }

        private ExternalSourcesHandled()
        {
            Register<ExternalSourceHandledEvent>(e => Id = e.AggregateId);
        }
    }
}
