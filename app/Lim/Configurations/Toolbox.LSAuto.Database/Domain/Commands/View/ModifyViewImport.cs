using System;
using Lim;
using Lim.Dtos;

namespace Toolbox.LightstoneAuto.Domain.Commands.View
{
    public class ModifyViewImport : Command
    {
        public ModifyViewImport(ViewDto view, Guid modifiedBy, long version, Guid correlationId)
        {
            View = view;
            EventType = Lim.Enums.EventType.Modified.ToString();
            EventTypeId = (int) Lim.Enums.EventType.Modified;
            NewAggregate = false;
            User = modifiedBy;
            Version = version;
            CorrelationId = correlationId;
            AggregateId = view.AggregateId;
            Type = GetType();
        }

        public readonly ViewDto View;
        public readonly string EventType;
        public readonly int EventTypeId;
        public readonly bool NewAggregate;
        public readonly Guid CorrelationId;
        public readonly long Version;
        public readonly Type Type;
    }
}