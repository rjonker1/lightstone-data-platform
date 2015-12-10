using System;
using Lim;
using Lim.Dtos;

namespace Toolbox.LightstoneAuto.Domain.Commands.View
{
    public class CreateViewImport : Command
    {
        public CreateViewImport(ViewDto view, Guid createdBy, Guid correlationId)
        {
            View = view;
            EventType = Lim.Enums.EventType.Created.ToString();
            EventTypeId = (int)Lim.Enums.EventType.Created;
            NewAggregate = true;
            User = createdBy;
            AggregateId = Guid.NewGuid();
            CorrelationId = correlationId;
            Type = GetType();
        }
        
        public readonly string EventType;
        public readonly int EventTypeId;
        public readonly Guid CorrelationId;
        public readonly bool NewAggregate;
        public readonly Type Type;
        public readonly ViewDto View;
    }
}
