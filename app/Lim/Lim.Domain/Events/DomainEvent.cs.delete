using System;
using System.Runtime.Serialization;
using Lim.Enums;

namespace Lim.Domain.Events
{
    [DataContract]public class DomainEvent
    {

        public DomainEvent(EventType eventType, AggregateType aggregateType, bool aggregateNew, Guid createdBy, Guid correlationId, byte[] payload)
        {
            Id = Guid.NewGuid();
            EventType = eventType.ToString();
            EventTypeId = (int)eventType;
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

        [DataMember]
        public Guid Id { get; private set; }
        [DataMember]
        public string EventType { get; private set; }
        [DataMember]
        public int EventTypeId { get; private set; }
        [DataMember]
        public string AggregrateType { get; private set; }
        [DataMember]
        public int AggregrateTypeId { get; private set; }
        [DataMember]
        public bool AggregateNew { get; private set; }
        [DataMember]
        public DateTime CommitStamp { get; private set; }
        [DataMember]
        public Guid CreatedBy { get; private set; }
        [DataMember]
        public Guid CorrelationId { get; private set; }
        [DataMember]
        public string TypeName { get; private set; }
        [DataMember]
        public Type Type  { get; private set; }
        [DataMember]
        public byte[] Payload { get; private set; }
    }
}
