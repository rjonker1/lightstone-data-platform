using System;
using EventTracking.Domain.Core;
using Monitoring.Events.Lace;
using Monitoring.Sources;

namespace Monitoring.Consumer.Lace.Aggregates
{
    public class ExternalSourcesConfiguration : AggregateBase
    {
        public ExternalSourcesConfiguration(Guid id, Guid aggregateId, FromSource source, string message,
            DateTime eventDate)
            : this()
        {
            RaiseEvent(new ExternalSourceConfigurationEvent(id, aggregateId, source.ToString(), message,
                eventDate));
        }

        private ExternalSourcesConfiguration()
        {
            Register<ExternalSourceConfigurationEvent>(e => Id = e.AggregateId);
        }
    }
}
