using System;

namespace LightstoneApp.Infrastructure.CrossCutting.NetFramework.EventSourcing
{
    public abstract class VersionedEvent : IVersionedEvent
    {
        public Guid SourceId { get; set; }

        public int Version { get; set; }
    }
}