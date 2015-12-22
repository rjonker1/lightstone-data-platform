using System;
using Lim.Domain.Events;
using Lim.Dtos;

namespace Toolbox.LightstoneAuto.Domain.Events
{
    public class DatabaseViewLoaded : LimEvent
    {
        public DatabaseViewLoaded(DatabaseViewDto databaseView, Guid correlationId, string eventType, int eventTypeId, bool newAggregate, string user, Type type)
        {
            DatabaseView = databaseView;
            EventType = eventType;
            EventTypeId = eventTypeId;
            Type = type;
            TypeName = type.Name;
            AggregateNew = newAggregate;
            User = user;
            CorrelationId = correlationId;
            AggregateId = databaseView.AggregateId;
        }

        public DatabaseViewDto DatabaseView { get; private set; }
    }
}