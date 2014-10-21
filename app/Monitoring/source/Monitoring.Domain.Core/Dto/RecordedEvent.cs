using System;
namespace Monitoring.Domain.Core.Dto
{
    public class RecordedEvent
    {
        public virtual byte[] Data { get; set; }
        public virtual Guid EventId { get; set; }
        public virtual int EventNumber { get; set; }
        public virtual string EventStreamId { get; set; }
        public virtual string EventType { get; set; }
        public virtual byte[] Metadata { get; set; }
    }
}
