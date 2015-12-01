using System;
using Toolbox.LightstoneAuto.Database.Domain.Enums;

namespace Toolbox.LightstoneAuto.Database.Domain
{
    public class DomainEvent
    {

        public DomainEvent(EventType eventType, AggregateType aggregateType, bool aggregateNew, Guid createdBy, Guid correlationId, byte[] payload)
        {
            Id = Guid.NewGuid();
            EventType = eventType.ToString();
            EventTypeId = (int) eventType;
            AggregateNew = aggregateNew;
            AggregrateType = aggregateType.ToString();
            AggregrateTypeId = (int)aggregateType;
            CreatedBy = createdBy;
            CorrelationId = correlationId;
            Payload = payload;
            CommitStamp = DateTime.UtcNow;
        }

        //public static DomainEvent ForNewAggregate()
        //{
            
        //}

        //public static DomainEvent ForExistingAggregate()
        //{
            
        //}

        public Guid Id { get; private set; }
        public string EventType { get; private set; }
        public int EventTypeId { get; private set; }
        public string AggregrateType { get; private set; }
        public int AggregrateTypeId { get; private set; }
        public bool AggregateNew { get; private set; }
        public DateTime CommitStamp { get; private set; }
        public Guid CreatedBy { get; private set; }
        public Guid CorrelationId { get; private set; }
        public byte[] Payload { get; private set; }}
}
