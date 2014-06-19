using EasyNetQ.AutoSubscribe;
using Monitoring.Consumer.Lace.Persistence;
using Monitoring.Consumer.Lace.Aggregates;
using Monitoring.Consumer.Lace.Messages;

namespace Monitoring.Consumer.Lace.Consumers
{
    public class ExternalSourceHandledConsumer : IConsume<LaceSourceHandledEventMessage>
    {
        public bool HasBeenConsumed { get; private set; }

        private readonly IPersistEvent _persistEvent;

        public ExternalSourceHandledConsumer()
        {
            _persistEvent = new PersistEvent();
        }

        public void Consume(LaceSourceHandledEventMessage message)
        {
            _persistEvent
                .Save(new ExternalSourcesHandled(message.Id, message.AggregateId, message.Source,
                    message.Message,
                    message.EventDate, message.Category));

            HasBeenConsumed = true;
        }
    }
}
