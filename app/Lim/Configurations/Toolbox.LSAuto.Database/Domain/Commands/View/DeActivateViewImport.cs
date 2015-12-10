using System;
using Lim;

namespace Toolbox.LightstoneAuto.Domain.Commands.View
{
    public class DeActivateViewImport : Command
    {
        public DeActivateViewImport(Guid viewId, Guid modifiedBy, long version, Guid correlationId)
        {
            ViewId = viewId;
            EventType = Lim.Enums.EventType.Deactivated.ToString();
            EventTypeId = (int)Lim.Enums.EventType.Deactivated;
            NewAggregate = false;
            User = modifiedBy;
            Version = version;
            CorrelationId = correlationId;
            AggregateId = viewId;
            Type = GetType();
        }


        public readonly Guid ViewId;
        public readonly string EventType;
        public readonly int EventTypeId;
        public readonly bool NewAggregate;
        public readonly long Version;
        public readonly Guid CorrelationId;
        public readonly Type Type;
    }
}
