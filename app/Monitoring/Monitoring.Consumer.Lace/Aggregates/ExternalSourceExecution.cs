using System;
using EventTracking.Domain.Core;
using Monitoring.Events.Lace;
using Monitoring.Sources.Lace;

namespace Monitoring.Consumer.Lace.Aggregates
{
    public class ExternalSourceExecution : AggregateBase
    {
        public ExternalSourceExecution(Guid id, Guid aggregateId, LaceEventSource source, string message, DateTime eventDate, string category, int order)
            : this()
        {
            Category = category;
            RaiseEvent(new ExternalSourceExecutedEvent(id, aggregateId, (int)source, message, eventDate, category, order));
        }

        private ExternalSourceExecution()
        {
            Register<ExternalSourceExecutedEvent>(e => Id = e.AggregateId);
        }
    }

}
