using System;

namespace LightstoneApp.Infrastructure.CrossCutting.NetFramework
{
    public abstract class DomainEvent : IDomainEvent
    {
        protected DomainEvent()
        {
        }

        protected DomainEvent(String aggregateId)
        {
            //Ensure.That( aggregateId ).Named( () => aggregateId ).IsNotNullNorEmpty();

            OccurredAt = DateTimeOffset.Now;
            AggregateId = aggregateId;
        }

        public string Id { get; set; }

        public string AggregateId { get; set; }

        public Int32 AggregateVersion { get; set; }

        public DateTimeOffset OccurredAt { get; private set; }
    }
}