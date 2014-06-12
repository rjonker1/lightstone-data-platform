using System;
using EventTracking.Domain.Core;
using Monitoring.Events.Lace;
using Monitoring.Sources.Lace;

namespace Monitoring.Consumer.Lace.Aggregates
{
    public class ExternalSourceInformation : AggregateBase
    {
        public ExternalSourceInformation(Guid id, Guid aggregateId, ExternalSource source, string message, DateTime eventDate)
            : this()
        {
            RaiseEvent(new ExternalSourceEvent(id, aggregateId, (int)source, message, eventDate));
        }

        private ExternalSourceInformation()
        {

            Register<ExternalSourceEvent>(e => Id = e.AggregateId);
        }

    }

}
