using System;
using Lim;

namespace Toolbox.LightstoneAuto.Domain.Commands.Dataset
{
    public class DeActivateDataSetExport : Command
    {
        public DeActivateDataSetExport(Guid dataSetId, Guid modifiedBy, long version, Guid correlationId)
        {
            DataSetId = dataSetId;
            EventType = Lim.Enums.EventType.Deactivated.ToString();
            EventTypeId = (int)Lim.Enums.EventType.Deactivated;
            NewAggregate = false;
            User = modifiedBy;
            Version = version;
            CorrelationId = correlationId;
            AggregateId = dataSetId;
        }

        public readonly Guid DataSetId;
        public readonly string EventType;
        public readonly int EventTypeId;
        public readonly bool NewAggregate;
        public readonly long Version;
        public readonly Guid CorrelationId;
    }
}