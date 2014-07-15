using EasyNetQ.AutoSubscribe;
using EventTracking.Domain.Persistence;
using Monitoring.Consumer.Lace.Aggregates;
using Monitoring.Consumer.Lace.Messages;

namespace Monitoring.Consumer.Lace.Consumers
{
    public class ExternalSourceSentRequestsConsumer : IConsume<LaceExternalSourceRequestEventMessage>
    {
        public bool HasBeenConsumed { get; private set; }

        private readonly IPersistEvent _persistEvent;

        public ExternalSourceSentRequestsConsumer(IPersistEvent persistEvent)
        {
            _persistEvent = persistEvent;
        }

        public void Consume(LaceExternalSourceRequestEventMessage message)
        {
            _persistEvent
                .Save(new ExternalSourcesRequestsSent(message.Id, message.AggregateId,
                    message.Source,
                    message.Message,
                    message.EventDate,
                    message.Payload, message.Category));

            HasBeenConsumed = true;
        }
    }
}