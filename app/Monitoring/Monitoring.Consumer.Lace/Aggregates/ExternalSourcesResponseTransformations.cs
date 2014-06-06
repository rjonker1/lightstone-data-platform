using System;
using EventTracking.Domain.Core;
using Monitoring.Events.Lace;
using Monitoring.Sources;

namespace Monitoring.Consumer.Lace.Aggregates
{
    public class ExternalSourcesResponseTransformations : AggregateBase
    {

        public ExternalSourcesResponseTransformations(Guid id, Guid aggregateId, FromSource source, string message,
            DateTime eventDate)
            : this()
        {
            RaiseEvent(new ExternalSourceResponseTransformationEvent(id, aggregateId, source.ToString(), message,
                eventDate));
        }

        private ExternalSourcesResponseTransformations()
        {
            Register<ExternalSourceResponseTransformationEvent>(e => Id = e.AggregateId);
        }
    }
}
