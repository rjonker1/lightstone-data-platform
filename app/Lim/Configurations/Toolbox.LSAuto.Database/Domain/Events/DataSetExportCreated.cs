using System;
using Lim;
using Lim.Dtos;

namespace Toolbox.LightstoneAuto.Domain.Events
{
    public class DataSetExportCreated : LimEvent
    {
        public DataSetExportCreated(DataSetDto dataSet, Guid correlationId,  string eventType, int eventTypeId, bool newAggregate, Guid user, Type type, Guid aggregateId)
        {
            DataSet = dataSet;
            EventType = eventType;
            EventTypeId = eventTypeId;
            Type = type;
            TypeName = type.Name;
            AggregateNew = newAggregate;
            User = user;
            CorrelationId = correlationId;
            AggregateId = aggregateId;
            //  Payload = Encoding.UTF8.GetBytes(this.ObjectToJson());

        }

        public readonly DataSetDto DataSet;
    }
}
