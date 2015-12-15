using System;
using Lim;
using Lim.Domain.Events;

namespace Toolbox.LightstoneAuto.Domain.Events
{
    public class DatabaseExtractDeActivated : LimEvent
    {
        public DatabaseExtractDeActivated(Guid dataSetId, Guid correlationId)
        {
            AggregateId = dataSetId;
            DataSetId = dataSetId;
            CorrelationId = correlationId;
        }

        public Guid DataSetId { get; private set; }
    }
}