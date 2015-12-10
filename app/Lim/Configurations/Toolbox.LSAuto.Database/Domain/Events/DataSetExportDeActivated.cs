using System;
using Lim;
using Lim.Domain.Events;

namespace Toolbox.LightstoneAuto.Domain.Events
{
    public class DataSetExportDeActivated : LimEvent
    {
        public DataSetExportDeActivated(Guid dataSetId, Guid correlationId)
        {
            AggregateId = dataSetId;
            DataSetId = dataSetId;
            CorrelationId = correlationId;
        }

        public Guid DataSetId { get; private set; }
    }
}