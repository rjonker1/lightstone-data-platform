using System;
using EventTracking.Domain.Core;
using Monitoring.Events.Lace;
using Monitoring.Sources.Lace;

namespace Monitoring.Consumer.Lace.Aggregates
{
    public class ExternalSourcesResponseTransformations : AggregateBase
    {

        public ExternalSourcesResponseTransformations(Guid id, Guid aggregateId, LaceEventSource source, string message,
            DateTime eventDate, string category)
            : this()
        {
            Category = category;
            RaiseEvent(new ExternalSourceResponseTransformationEvent(id, aggregateId, (int)source, message,
                eventDate,category));
        }

        private ExternalSourcesResponseTransformations()
        {
            Register<ExternalSourceResponseTransformationEvent>(e => Id = e.AggregateId);
        }
    }
}
