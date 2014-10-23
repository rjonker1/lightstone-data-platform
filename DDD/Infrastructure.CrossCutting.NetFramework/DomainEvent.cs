using System;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.Utils;

namespace LightstoneApp.Infrastructure.CrossCutting.NetFramework
{
    public abstract class DomainEvent : IDomainEvent
    {
        protected DomainEvent()
        {
            Id = GuidUtil.NewSequentialId().ToString();
        }

        protected DomainEvent(String aggregateId)
        {
            //Ensure.That( aggregateId ).Named( () => aggregateId ).IsNotNullNorEmpty();

            OccurredAt = DateTime.Now;
            AggregateId = aggregateId;
        }

        public string Id { get;  set; }

        public string AggregateId { get; set; }

        public Int32 AggregateVersion { get; set; }

        public DateTimeOffset OccurredAt { get; private set; }
    }
}