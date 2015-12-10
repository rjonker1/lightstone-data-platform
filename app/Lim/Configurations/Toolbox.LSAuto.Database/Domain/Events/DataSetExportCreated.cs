using System;
using Lim;
using Lim.Domain.Events;
using Lim.Dtos;

namespace Toolbox.LightstoneAuto.Domain.Events
{
    public class DataSetExportCreated : LimEvent
    {
        public DataSetExportCreated(DataSetDto dataSet, Guid correlationId,  string eventType, int eventTypeId, bool newAggregate, Guid user, Type type)
        {
            DataSet = dataSet;
            EventType = eventType;
            EventTypeId = eventTypeId;
            Type = type;
            TypeName = type.Name;
            AggregateNew = newAggregate;
            User = user;
            CorrelationId = correlationId;
            AggregateId = dataSet.AggregateId;
            DataSet.CreatedBy = User;
            //  Payload = Encoding.UTF8.GetBytes(this.ObjectToJson());

        }

        public DataSetDto DataSet { get; private set; }
    }
}
