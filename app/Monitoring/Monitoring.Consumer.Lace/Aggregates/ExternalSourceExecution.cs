using System;
using EventTracking.Domain.Core;
using Monitoring.Events.Lace;
using Monitoring.Sources.Lace;

namespace Monitoring.Consumer.Lace.Aggregates
{
    public class ExternalSourceExecution : AggregateBase
    {
        public ExternalSourceExecution(Guid id, Guid aggregateId, LaceEventSource source, string message, DateTime eventDate, string category)
            : this()
        {
            Category = category;
            RaiseEvent(new ExternalSourceEvent(id, aggregateId, (int)source, message, eventDate,category));
        }

        private ExternalSourceExecution()
        {

            Register<ExternalSourceEvent>(e => Id = e.AggregateId);
        }

    }

}
