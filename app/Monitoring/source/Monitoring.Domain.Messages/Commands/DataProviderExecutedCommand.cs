using System;
using Monitoring.Domain.Core;
using Monitoring.Domain.Core.Dto;
using Monitoring.Domain.Messages.Events;

namespace Monitoring.Domain.Messages.Commands
{
    public class DataProviderExecutedCommand
    {
        public readonly Guid EventId;
        public readonly Guid AggregateId;
        public readonly EventData Data;

        public DataProviderExecutedCommand(Guid eventId, Guid aggregateId, DataProviderExecuted eventMessage)
        {
            EventId = eventId;
            AggregateId = aggregateId;
            Data = eventMessage.AsJsonEvent();
        }
    }
}
