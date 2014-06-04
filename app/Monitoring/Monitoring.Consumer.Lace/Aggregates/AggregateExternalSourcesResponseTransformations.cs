using System;
using EventTracking.Domain.Core;
using Monitoring.Consumer.Lace.Events;
using Monitoring.Sources;

namespace Monitoring.Consumer.Lace.Aggregates
{
    public class AggregateExternalSourcesResponseTransformations : AggregateBase
    {

        public AggregateExternalSourcesResponseTransformations(Guid id, Guid aggregateId, FromSource source, string message,
            DateTime eventDate)
            : this()
        {
            RaiseEvent(new ExternalSourceResponseTransformationEvent(id, aggregateId, source.ToString(), message,
                eventDate));
        }

        private AggregateExternalSourcesResponseTransformations()
        {
            Register<ExternalSourceResponseTransformationEvent>(e => Id = e.AggregateId);
        }
    }
}
