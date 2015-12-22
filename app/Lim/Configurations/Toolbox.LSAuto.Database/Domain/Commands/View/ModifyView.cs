using System;
using Lim;
using Lim.Dtos;

namespace Toolbox.LightstoneAuto.Domain.Commands.View
{
    public class ModifyView : Command
    {
        public ModifyView(DatabaseViewDto databaseView, string modifiedBy, long version, Guid correlationId)
        {
            DatabaseView = databaseView;
            EventType = Lim.Enums.EventType.Modified.ToString();
            EventTypeId = (int) Lim.Enums.EventType.Modified;
            NewAggregate = false;
            User = modifiedBy;
            Version = version;
            CorrelationId = correlationId;
            AggregateId = databaseView.AggregateId;
            Type = GetType();
        }

        public readonly DatabaseViewDto DatabaseView;
        public readonly string EventType;
        public readonly int EventTypeId;
        public readonly bool NewAggregate;
        public readonly Guid CorrelationId;
        public readonly long Version;
        public readonly Type Type;
    }
}