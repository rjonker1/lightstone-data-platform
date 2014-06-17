using System;
using EventTracking.Domain.Core;
using Monitoring.Events.Lace;
using Monitoring.Sources.Lace;

namespace Monitoring.Consumer.Lace.Aggregates
{
    public class ExternalSourcesConfiguration : AggregateBase
    {
        public ExternalSourcesConfiguration(Guid id, Guid aggregateId, LaceEventSource source, string message,
            DateTime eventDate)
            : this()
        {
            RaiseEvent(new ExternalSourceConfigurationEvent(id, aggregateId, (int)source, message,
                eventDate));
        }

        private ExternalSourcesConfiguration()
        {
            Register<ExternalSourceConfigurationEvent>(e => Id = e.AggregateId);
        }
    }
}
