﻿using EasyNetQ.AutoSubscribe;
using EventTracking.Domain.Persistence;
using Monitoring.Consumer.Lace.Aggregates;
using Monitoring.Consumer.Lace.Messages;

namespace Monitoring.Consumer.Lace.Consumers
{
    public class ExternalSourceExecutedConsumer : IConsume<LaceExternalSourceExecutionEventMessage>
    {
        public bool HasBeenConsumed { get; private set; }

        private readonly IPersistAnEvent _persistEvent;

        public ExternalSourceExecutedConsumer(IPersistAnEvent persistEvent)
        {
            _persistEvent = persistEvent;
        }

        public void Consume(LaceExternalSourceExecutionEventMessage message)
        {
            _persistEvent
                .Save(new ExternalSourceExecution(message.Id, message.AggregateId, message.Source,
                    message.Message,
                    message.EventDate, message.Category, message.Order));

            HasBeenConsumed = true;
        }
    }
}