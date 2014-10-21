using System;
using Monitoring.Domain.Core.Dto;
using NServiceBus.Saga;

namespace Monitoring.Domain.Subscriber.Models
{
    public class DataProviderEvents : ContainSagaData
    {
        [Unique]
        public virtual long EventNumber { get; set; }

        public virtual Guid EventId { get; set; }
        public virtual Guid AggregateId { get; set; }
        public virtual EventData Event { get; set; }
    }
}
