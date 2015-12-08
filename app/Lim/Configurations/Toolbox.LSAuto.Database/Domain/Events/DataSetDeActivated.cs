using System;
using Lim;
using Lim.Domain.Events;

namespace Toolbox.LightstoneAuto.Domain.Events
{
    public class DataSetDeActivated : LimEvent
    {
        public DataSetDeActivated(Guid dataSetId, Guid correlationId)
        {
            AggregateId = dataSetId;
            DataSetId = dataSetId;
            CorrelationId = correlationId;
        }

        public readonly Guid DataSetId;
    }
}