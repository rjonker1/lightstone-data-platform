using System;
using Lim;

namespace Toolbox.LightstoneAuto.Domain.Events
{
    public class DataSetDeActivated : LimEvent
    {
        public DataSetDeActivated(long aggregateId, long dataSetId, Guid correlationId)
        {
            Id = aggregateId;
            DataSetId = dataSetId;
            CorrelationId = correlationId;
        }

        public readonly long DataSetId;
    }
}