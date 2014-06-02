using System;


namespace Monitoring.Modules.Lace.AggregateEvents
{
    public class ExternalSourceAggregateCreated
    {
        public ExternalSourceAggregateCreated(Guid aggregateId)
        {
            AggregateId = aggregateId;
        }
        public Guid AggregateId { get; private set; }

    }
}
