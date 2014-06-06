using System;
using EventTracking.Domain.Core;
using Monitoring.Events.Lace;
using Monitoring.Sources;

namespace Monitoring.Consumer.Lace.Aggregates
{
    public class ExternalSourceInformation : AggregateBase
    {
        public ExternalSourceInformation(Guid id, Guid aggregateId, FromSource source, string message, DateTime eventDate)
            : this()
        {
            RaiseEvent(new ExternalSourceEvent(id, aggregateId, source.ToString(), message, eventDate));
        }

        private ExternalSourceInformation()
        {

            Register<ExternalSourceEvent>(e => Id = e.AggregateId);
        }

    }

}
