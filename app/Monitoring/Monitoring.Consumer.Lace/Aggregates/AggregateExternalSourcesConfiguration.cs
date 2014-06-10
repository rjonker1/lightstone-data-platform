using System;
using EventTracking.Domain.Core;
using Monitoring.Consumer.Lace.Events;
using Monitoring.Sources;

namespace Monitoring.Consumer.Lace.Aggregates
{
    public class AggregateExternalSourcesConfiguration : AggregateBase
    {
        public AggregateExternalSourcesConfiguration(Guid id, Guid aggregateId, FromSource source, string message,
            DateTime eventDate)
            : this()
        {
            RaiseEvent(new ExternalSourceConfigurationEvent(id, aggregateId, source.ToString(), message,
                eventDate));
        }

        private AggregateExternalSourcesConfiguration()
        {
            Register<ExternalSourceConfigurationEvent>(e => Id = e.AggregateId);
        }
    }
}
