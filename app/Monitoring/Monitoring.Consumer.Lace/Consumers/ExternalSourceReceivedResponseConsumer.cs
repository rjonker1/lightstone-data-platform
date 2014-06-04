using EasyNetQ.AutoSubscribe;
using Monitoring.Consumer.Lace.Persistence;
using Monitoring.Consumer.Lace.Aggregates;
using Monitoring.Consumer.Lace.Messages;

namespace Monitoring.Consumer.Lace.Consumers
{
    public class ExternalSourceReceivedResponseConsumer : IConsume<LaceExternalSourceResponseEventMessage>
    {
        public bool HasBeenConsumed { get; private set; }

        private readonly IPersistEvent _persistEvent;

        public ExternalSourceReceivedResponseConsumer()
        {
            _persistEvent = new PersistEvent();
        }

        public void Consume(LaceExternalSourceResponseEventMessage message)
        {
            _persistEvent
                .Save(new AggregateExternalSourcesResponseSuccesses(message.Id, message.AggregateId,
                    message.Source,
                    message.Message,
                    message.EventDate));

            HasBeenConsumed = true;
        }
    }
}
