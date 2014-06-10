using EasyNetQ.AutoSubscribe;
using Monitoring.Consumer.Lace.Persistence;
using Monitoring.Consumer.Lace.Aggregates;
using Monitoring.Consumer.Lace.Messages;

namespace Monitoring.Consumer.Lace.Consumers
{
    public class ExternalSourceSentRequestsConsumer : IConsume<LaceExternalSourceRequestEventMessage>
    {
        public bool HasBeenConsumed { get; private set; }

        private readonly IPersistEvent _persistEvent;

        public ExternalSourceSentRequestsConsumer()
        {
            _persistEvent = new PersistEvent();
        }

        public void Consume(LaceExternalSourceRequestEventMessage message)
        {
            _persistEvent
                .Save(new ExternalSourcesRequestsSent(message.Id, message.AggregateId,
                    message.Source,
                    message.Message,
                    message.EventDate,
                    message.Payload));

            HasBeenConsumed = true;
        }
    }
}