using System;
using Lim.Core;

namespace Lim
{
    public class LimEvent : IMessage
    {
        public int Version { get;  set; }
        public string EventType { get; protected set; }
        public int EventTypeId { get; protected set; }
        public bool AggregateNew { get; protected set; }
        public Guid CorrelationId { get; protected set; }
        public string Type { get; protected set; }
        public string TypeName { get; protected set; }
        public byte[] Payload { get; protected set; }
        public Guid User { get; protected set; }
    }
}
