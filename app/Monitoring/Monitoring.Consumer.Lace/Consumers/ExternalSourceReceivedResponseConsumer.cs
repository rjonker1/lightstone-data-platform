using EasyNetQ.AutoSubscribe;
using EventTracking.Domain.Persistence;
using Monitoring.Consumer.Lace.Aggregates;
using Monitoring.Consumer.Lace.Messages;

namespace Monitoring.Consumer.Lace.Consumers
{
    public class ExternalSourceReceivedResponseConsumer : IConsume<LaceExternalSourceResponseEventMessage>
    {
        public bool HasBeenConsumed { get; private set; }

        private readonly IPersistAnEvent _persistEvent;

        public ExternalSourceReceivedResponseConsumer(IPersistAnEvent persistEvent)
        {
            _persistEvent = persistEvent;
        }

        public void Consume(LaceExternalSourceResponseEventMessage message)
        {
            _persistEvent
                .Save(new ExternalSourcesResponseSuccesses(message.Id, message.AggregateId,
                    message.Source,
                    message.Message,
                    message.EventDate,
                    message.Payload, message.Category));

            HasBeenConsumed = true;
        }
    }
}
