using System;
using Lim.Domain.Events;
using Lim.Dtos;

namespace Toolbox.LightstoneAuto.Domain.Events
{
    public class DatabaseViewModified : LimEvent
    {
        public DatabaseViewModified(DatabaseViewDto databaseView, Guid correlationId, string eventType, int eventTypeId, bool newAggregate,
            string user, long version, Type type)
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
            Version = version;
            DatabaseView.Version = version;
        }

        public DatabaseViewDto DatabaseView { get; private set; }
    }
}
