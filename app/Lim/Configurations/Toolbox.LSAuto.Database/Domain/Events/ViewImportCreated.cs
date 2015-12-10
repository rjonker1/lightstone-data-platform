using System;
using Lim.Domain.Events;
using Lim.Dtos;

namespace Toolbox.LightstoneAuto.Domain.Events
{
    public class ViewImportCreated : LimEvent
    {
        public ViewImportCreated(ViewDto view, Guid correlationId, string eventType, int eventTypeId, bool newAggregate, Guid user, Type type)
        {
            View = view;
            EventType = eventType;
            EventTypeId = eventTypeId;
            Type = type;
            TypeName = type.Name;
            AggregateNew = newAggregate;
            User = user;
            CorrelationId = correlationId;
            AggregateId = view.AggregateId;
        }

        public ViewDto View { get; private set; }
    }
}