using System;
using Lim;
using Toolbox.LightstoneAuto.Database.Infrastructure.Dto;

namespace Toolbox.LightstoneAuto.Database.Domain.Events
{
    public class DataSetExportCreated : LimEvent
    {
        public DataSetExportCreated(DataSetDto dataSet,string eventType, int eventTypeId, string type, bool newAggregate, Guid createdBy)
        {
            Id = Guid.NewGuid();
            DataSet = dataSet;
            EventType = eventType;
            EventTypeId = eventTypeId ;
            Type = type;
            NewAggregate = newAggregate;
            CreatedBy = createdBy;
        }

        public readonly Guid Id;
        public readonly DataSetDto DataSet;
        public readonly string EventType;
        public readonly int EventTypeId;
        public readonly string Type;
        public readonly bool NewAggregate;
        public readonly Guid CreatedBy;
    }
}
