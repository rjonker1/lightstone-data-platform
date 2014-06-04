using System;
using EventTracking.Domain.Core;
using Monitoring.Consumer.Lace.Events;
using Monitoring.Sources;

namespace Monitoring.Consumer.Lace.Aggregates
{
    public class AggregateExternalSourceInformation : AggregateBase
    {
        public AggregateExternalSourceInformation(Guid id, Guid aggregateId, FromSource source, string message, DateTime eventDate)
            : this()
        {
            RaiseEvent(new ExternalSourceEvent(id, aggregateId, source.ToString(), message, eventDate));
        }

        private AggregateExternalSourceInformation()
        {

            Register<ExternalSourceEvent>(e => Id = e.AggregateId);
        }

    }

}
