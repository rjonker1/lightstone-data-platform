using EasyNetQ.AutoSubscribe;
using Monitoring.Consumer.Lace.Persistence;
using Monitoring.Consumer.Lace.Aggregates;
using Monitoring.Consumer.Lace.Messages;

namespace Monitoring.Consumer.Lace.Consumers
{
    public class ExternalSourceNoResponseReceivedConsumer : IConsume<LaceExternalSourceNoResponseEventMessage>
    {
        public bool HasBeenConsumed { get; private set; }

        private readonly IPersistEvent _persistEvent;

        public ExternalSourceNoResponseReceivedConsumer()
        {
            _persistEvent = new PersistEvent();
        }

        public void Consume(LaceExternalSourceNoResponseEventMessage message)
        {
            _persistEvent
                .Save(new ExternalSourcesResponseFailures(message.Id, message.AggregateId,
                    message.Source,
                    message.Message,
                    message.EventDate, message.Category));

            HasBeenConsumed = true;
        }
    }
}
