using System;
using Lim;

namespace Toolbox.LightstoneAuto.Domain.Events
{
    public class DataSetDeActivated : LimEvent
    {
        public DataSetDeActivated(Guid aggregateId, long dataSetId, Guid correlationId)
        {
            AggregateId = aggregateId;
            DataSetId = dataSetId;
            CorrelationId = correlationId;
        }

        public readonly long DataSetId;
    }
}