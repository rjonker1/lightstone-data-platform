using System;
using EventTracking.Domain.Core;
using Monitoring.Modules.Lace.AggregateEvents;
using Monitoring.Sources;

namespace Monitoring.Modules.Lace.Aggregates
{
    public class AggregateExternalSourcesHandled : AggregateBase
    {

        public AggregateExternalSourcesHandled(Guid id, Guid aggregateId, FromSource source, string message,
            DateTime eventDate)
            : this()
        {
            RaiseEvent(new AggregateExternalSourceHandledEvent(id, aggregateId, source.ToString(), message, eventDate));
        }

        private AggregateExternalSourcesHandled()
        {
            Register<AggregateExternalSourceHandledEvent>(e => Id = e.AggregateId);
        }
    }
}
