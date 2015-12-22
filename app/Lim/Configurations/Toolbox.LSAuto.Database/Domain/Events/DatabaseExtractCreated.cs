using System;
using Lim.Domain.Events;
using Lim.Dtos;

namespace Toolbox.LightstoneAuto.Domain.Events
{
    public class DatabaseExtractCreated : LimEvent
    {
        public DatabaseExtractCreated(DatabaseExtractDto databaseExtract, Guid correlationId,  string eventType, int eventTypeId, bool newAggregate, string user, Type type)
        {
            DatabaseExtract = databaseExtract;
            EventType = eventType;
            EventTypeId = eventTypeId;
            Type = type;
            TypeName = type.Name;
            AggregateNew = newAggregate;
            User = user;
            CorrelationId = correlationId;
            AggregateId = databaseExtract.AggregateId;
            DatabaseExtract.CreatedBy = User;
            //  Payload = Encoding.UTF8.GetBytes(this.ObjectToJson());

        }

        public DatabaseExtractDto DatabaseExtract { get; private set; }
    }
}
