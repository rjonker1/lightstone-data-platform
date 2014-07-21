using EasyNetQ.AutoSubscribe;
using EventTracking.Domain.Persistence;
using Monitoring.Consumer.Lace.Aggregates;
using Monitoring.Consumer.Lace.Messages;

namespace Monitoring.Consumer.Lace.Consumers
{
    public class ExternalSourceFailedConsumer : IConsume<LaceExternalSourceFailedEventMessage>
    {
        public bool HasBeenConsumed { get; private set; }

        private readonly IPersistAnEvent _persistEvent;

        public ExternalSourceFailedConsumer(IPersistAnEvent persistEvent)
        {
            _persistEvent = persistEvent;
        }

        public void Consume(LaceExternalSourceFailedEventMessage message)
        {
            _persistEvent
                .Save(new ExternalSourceFailures(message.Id, message.AggregateId, message.Source,
                    message.Message,
                    message.EventDate,message.Category));

            HasBeenConsumed = true;
        }
    }
}
