using System;
using Lim.Domain.Events;
using Lim.Dtos;

namespace Toolbox.LightstoneAuto.Domain.Events
{
    public class DataSetExportModified : LimEvent
    {
        public DataSetExportModified(DataSetDto dataSet, Guid correlationId, string eventType, int eventTypeId, bool newAggregate, Guid user, Type type)
        {
            AggregateId = dataSet.AggregateId;
            DataSet = dataSet;
            EventType = eventType;
            EventTypeId = eventTypeId;
            Type = type;
            TypeName = type.Name;
            AggregateNew = newAggregate;
            User = user;
            CorrelationId = correlationId;
          //  Payload = Encoding.UTF8.GetBytes(this.ObjectToJson());
            
        }

        public DataSetDto DataSet { get; private set; }
    }
}
