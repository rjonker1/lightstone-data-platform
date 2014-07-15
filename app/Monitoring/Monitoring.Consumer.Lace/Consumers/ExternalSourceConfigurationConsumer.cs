using EasyNetQ.AutoSubscribe;
using EventTracking.Domain.Persistence;
using Monitoring.Consumer.Lace.Aggregates;
using Monitoring.Consumer.Lace.Messages;

namespace Monitoring.Consumer.Lace.Consumers
{
    public class ExternalSourceConfigurationConsumer : IConsume<LaceExternalSourceConfigurationEventMessage>
    {
        public bool HasBeenConsumed { get; private set; }

        private readonly IPersistEvent _persistEvent;

        public ExternalSourceConfigurationConsumer(IPersistEvent persistEvent)
        {
            _persistEvent = persistEvent;
        }

        public void Consume(LaceExternalSourceConfigurationEventMessage message)
        {
            _persistEvent
                .Save(new ExternalSourcesConfiguration(message.Id, message.AggregateId,
                    message.Source,
                    message.Message,
                    message.EventDate,message.Category));

            HasBeenConsumed = true;
        }
    }
}
