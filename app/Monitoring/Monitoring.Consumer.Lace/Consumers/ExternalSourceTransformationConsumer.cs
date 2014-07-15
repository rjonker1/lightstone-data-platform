using EasyNetQ.AutoSubscribe;
using EventTracking.Domain.Persistence;
using Monitoring.Consumer.Lace.Aggregates;
using Monitoring.Consumer.Lace.Messages;

namespace Monitoring.Consumer.Lace.Consumers
{
    public class ExternalSourceTransformationConsumer : IConsume<LaceTransformResponseEventMessage>
    {
        public bool HasBeenConsumed { get; private set; }

        private readonly IPersistEvent _persistEvent;

        public ExternalSourceTransformationConsumer(IPersistEvent persistEvent)
        {
            _persistEvent = persistEvent;
        }

        public void Consume(LaceTransformResponseEventMessage message)
        {
            _persistEvent
                .Save(new ExternalSourcesResponseTransformations(message.Id, message.AggregateId,
                    message.Source,
                    message.Message,
                    message.EventDate, message.Category));

            HasBeenConsumed = true;
        }
    }
}
