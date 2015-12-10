using System;
using Lim;
using Lim.Dtos;

namespace Toolbox.LightstoneAuto.Domain.Commands.View
{
    public class ReloadViewImport : Command
    {
        public ReloadViewImport(ViewDto view, Guid createdBy, Guid correlationId, long version)
        {
            View = view;
            EventType = Lim.Enums.EventType.Reloaded.ToString();
            EventTypeId = (int) Lim.Enums.EventType.Reloaded;
            NewAggregate = false;
            User = createdBy;
            AggregateId = view.AggregateId;
            CorrelationId = correlationId;
            Type = GetType();
            Version = version;
        }

        public readonly ViewDto View;
        public readonly string EventType;
        public readonly int EventTypeId;
        public readonly Guid CorrelationId;
        public readonly bool NewAggregate;
        public readonly long Version;
        public readonly Type Type;
    }
}