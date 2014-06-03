using System;
using EventTracking.Domain.Core;
using Monitoring.Modules.Lace.AggregateEvents;
using Monitoring.Sources;

namespace Monitoring.Modules.Lace.Aggregates
{
    public class AggregateExternalSourcesConfiguration : AggregateBase
    {
        public AggregateExternalSourcesConfiguration(Guid id, Guid aggregateId, FromSource source, string message,
            DateTime eventDate)
            : this()
        {
            RaiseEvent(new AggregateExternalSourceConfigurationEvent(id, aggregateId, source.ToString(), message,
                eventDate));
        }

        private AggregateExternalSourcesConfiguration()
        {
            Register<AggregateExternalSourceConfigurationEvent>(e => Id = e.AggregateId);
        }
    }
}
