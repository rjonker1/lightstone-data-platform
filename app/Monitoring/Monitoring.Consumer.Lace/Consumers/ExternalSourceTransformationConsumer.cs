using EasyNetQ.AutoSubscribe;
using Monitoring.Consumer.Lace.Persistence;
using Monitoring.Consumer.Lace.Aggregates;
using Monitoring.Consumer.Lace.Messages;

namespace Monitoring.Consumer.Lace.Consumers
{
    public class ExternalSourceTransformationConsumer : IConsume<LaceTransformResponseEventMessage>
    {
        public bool HasBeenConsumed { get; private set; }

        private readonly IPersistEvent _persistEvent;

        public ExternalSourceTransformationConsumer()
        {
            _persistEvent = new PersistEvent();
        }

        public void Consume(LaceTransformResponseEventMessage message)
        {
            _persistEvent
                .Save(new ExternalSourcesResponseTransformations(message.Id, message.AggregateId,
                    message.Source,
                    message.Message,
                    message.EventDate));

            HasBeenConsumed = true;
        }
    }
}
