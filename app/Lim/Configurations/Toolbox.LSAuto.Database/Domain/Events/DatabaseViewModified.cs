using System;
using Lim.Domain.Events;
using Lim.Dtos;

namespace Toolbox.LightstoneAuto.Domain.Events
{
    public class DatabaseViewModified : LimEvent
    {
        public DatabaseViewModified(DatabaseViewDto databaseView, Guid correlationId, string eventType, int eventTypeId, bool newAggregate, Guid user, Type type)
        {
            AggregateId = databaseView.AggregateId;
            DatabaseView = databaseView;
            EventType = eventType;
            EventTypeId = eventTypeId;
            Type = type;
            TypeName = type.Name;
            AggregateNew = newAggregate;
            User = user;
            CorrelationId = correlationId;
        }

        public DatabaseViewDto DatabaseView { get; private set; }
    }
}
