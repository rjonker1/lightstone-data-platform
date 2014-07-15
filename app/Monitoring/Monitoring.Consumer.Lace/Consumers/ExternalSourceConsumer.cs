using EasyNetQ.AutoSubscribe;
using EventTracking.Domain.Persistence;
using Monitoring.Consumer.Lace.Aggregates;
using Monitoring.Consumer.Lace.Messages;

namespace Monitoring.Consumer.Lace.Consumers
{
    public class ExternalSourceConsumer : IConsume<LaceExternalSourceEventMessage>
    {
        public bool HasBeenConsumed { get; private set; }

        private readonly IPersistEvent _persistEvent;

        public ExternalSourceConsumer(IPersistEvent persistEvent)
        {
            _persistEvent = persistEvent;
        }

        public void Consume(LaceExternalSourceEventMessage message)
        {
            _persistEvent
                .Save(new ExternalSourceInformation(message.Id, message.AggregateId, message.Source,
                    message.Message,
                    message.EventDate, message.Category));

            HasBeenConsumed = true;
        }
    }
}
