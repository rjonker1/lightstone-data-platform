using System;
namespace Lim.Domain.EventStore.Entities
{
    public class EventCommand
    {
        public virtual long Id { get; set; }
        public virtual long AggregateId { get; set; }
        public virtual string EventType { get; set; }
        public virtual int EventTypeId { get; set; }
        public virtual bool AggregateNew { get; set; }
        public virtual DateTime CommitStamp { get; set; }
        public virtual Guid CorrelationId { get; set; }
        public virtual string Type { get; set; }
        public virtual string TypeName { get; set; }
        public virtual byte[] Payload { get; set; }
        public virtual long Version { get; set; }
        public Guid User { get; set; }
    }
}
