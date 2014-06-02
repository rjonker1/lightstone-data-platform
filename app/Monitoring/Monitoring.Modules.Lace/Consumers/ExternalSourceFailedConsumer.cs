using EasyNetQ.AutoSubscribe;
using EventTracking.Domain.Persistence.Storage;
using Monitoring.Modules.Lace.Aggregates;
using Monitoring.Modules.Lace.Messages;

namespace Monitoring.Modules.Lace.Consumers
{
    public class ExternalSourceFailedConsumer : IConsume<LaceExternalServiceFailedEventMessage>
    {
        public bool HasBeenConsumed { get; private set; }

        public void Consume(LaceExternalServiceFailedEventMessage message)
        {
            var aggregate = new ExternalServiceFailedAggregate(message.AggregateId);
            aggregate.ProduceEvent(message.Id, message.Source, message.Message, message.EventDate);

            EventStoreEndpointManager.Instance.Save(aggregate, message.Id, d => { });

            HasBeenConsumed = true;
        }
    }
}
