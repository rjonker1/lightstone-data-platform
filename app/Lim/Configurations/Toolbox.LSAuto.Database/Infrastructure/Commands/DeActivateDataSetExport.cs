﻿using System;
using Lim;

namespace Toolbox.LightstoneAuto.Infrastructure.Commands
{
    public class DeActivateDataSetExport : Command
    {
        public DeActivateDataSetExport(long dataSetId, Guid modifiedBy, int version, Guid correlationId, Guid aggregateId)
        {
            DataSetId = dataSetId;
            EventType = Lim.Enums.EventType.Deactivated.ToString();
            EventTypeId = (int)Lim.Enums.EventType.Deactivated;
            NewAggregate = false;
            User = modifiedBy;
            Version = version;
            CorrelationId = correlationId;
            AggregateId = aggregateId;
        }

        public readonly long DataSetId;
        public readonly Guid AggregateId;
        public readonly string EventType;
        public readonly int EventTypeId;
        public readonly bool NewAggregate;
        public readonly Guid User;
        public readonly int Version;
        public readonly Guid CorrelationId;
    }
}