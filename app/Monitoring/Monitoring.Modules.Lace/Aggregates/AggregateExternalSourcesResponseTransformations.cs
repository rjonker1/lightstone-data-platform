using System;
using EventTracking.Domain.Core;
using Monitoring.Modules.Lace.AggregateEvents;
using Monitoring.Sources;

namespace Monitoring.Modules.Lace.Aggregates
{
    public class AggregateExternalSourcesResponseTransformations : AggregateBase
    {

        public AggregateExternalSourcesResponseTransformations(Guid id, Guid aggregateId, FromSource source, string message,
            DateTime eventDate)
            : this()
        {
            RaiseEvent(new AggregateExternalSourceResponseTransformationEvent(id, aggregateId, source.ToString(), message,
                eventDate));
        }

        private AggregateExternalSourcesResponseTransformations()
        {
            Register<AggregateExternalSourceResponseTransformationEvent>(e => Id = e.AggregateId);
        }
    }
}
