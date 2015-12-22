using System;
using Lim;
using Lim.Dtos;

namespace Toolbox.LightstoneAuto.Domain.Commands.View
{
    public class LoadView : Command
    {
        public LoadView(DatabaseViewDto databaseView, string createdBy, Guid correlationId)
        {
            DatabaseView = databaseView;
            EventType = Lim.Enums.EventType.Created.ToString();
            EventTypeId = (int)Lim.Enums.EventType.Created;
            NewAggregate = true;
            User = createdBy;
            AggregateId = Guid.NewGuid();
            CorrelationId = correlationId;
            Type = GetType();
            databaseView.AggregateId = AggregateId;
        }
        
        public readonly string EventType;
        public readonly int EventTypeId;
        public readonly Guid CorrelationId;
        public readonly bool NewAggregate;
        public readonly Type Type;
        public readonly DatabaseViewDto DatabaseView;
    }
}
