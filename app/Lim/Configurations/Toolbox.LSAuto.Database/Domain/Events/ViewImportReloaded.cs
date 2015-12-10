using System;
using Lim.Domain.Events;
using Lim.Dtos;

namespace Toolbox.LightstoneAuto.Domain.Events
{
    public class ViewImportReloaded : LimEvent
    {
        public ViewImportReloaded(ViewDto view, Guid correlationId, string eventType, int eventTypeId, bool newAggregate, Guid user, Type type)
        {
            AggregateId = view.AggregateId;
            View = view;
            EventType = eventType;
            EventTypeId = eventTypeId;
            Type = type;
            TypeName = type.Name;
            AggregateNew = newAggregate;
            User = user;
            CorrelationId = correlationId;
        }

        public readonly ViewDto View;
    }
}
