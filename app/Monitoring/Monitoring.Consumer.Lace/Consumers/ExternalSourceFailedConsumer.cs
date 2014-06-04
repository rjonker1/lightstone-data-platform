using EasyNetQ.AutoSubscribe;
using Monitoring.Consumer.Lace.Persistence;
using Monitoring.Consumer.Lace.Aggregates;
using Monitoring.Consumer.Lace.Messages;

namespace Monitoring.Consumer.Lace.Consumers
{
    public class ExternalSourceFailedConsumer : IConsume<LaceExternalSourceFailedEventMessage>
    {
        public bool HasBeenConsumed { get; private set; }

        private readonly IPersistEvent _persistEvent;

        public ExternalSourceFailedConsumer()
        {
            _persistEvent = new PersistEvent();
        }

        public void Consume(LaceExternalSourceFailedEventMessage message)
        {
            _persistEvent
                .Save(new AggregateExternalSourceFailures(message.Id, message.AggregateId, message.Source,
                    message.Message,
                    message.EventDate));

            HasBeenConsumed = true;
        }
    }
}
