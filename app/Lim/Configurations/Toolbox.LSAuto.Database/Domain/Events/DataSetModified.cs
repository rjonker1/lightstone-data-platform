using System;
using Lim;
using Lim.Dtos;

namespace Toolbox.LightstoneAuto.Database.Domain.Events
{
    public class DataSetModified : LimEvent
    {
        public DataSetModified(long aggregateId, DataSetDto dataSet, Guid correlationId, string eventType, int eventTypeId, bool newAggregate, Guid user, Type type)
        {
            Id = aggregateId;
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

        public readonly DataSetDto DataSet;
    }
}
