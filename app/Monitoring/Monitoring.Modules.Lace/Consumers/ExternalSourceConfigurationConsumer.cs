using EasyNetQ.AutoSubscribe;
using Monitoring.Modules.Lace.AggregatePersistence;
using Monitoring.Modules.Lace.Aggregates;
using Monitoring.Modules.Lace.Messages;

namespace Monitoring.Modules.Lace.Consumers
{
    public class ExternalSourceConfigurationConsumer : IConsume<LaceExternalSourceConfigurationEventMessage>
    {
        public bool HasBeenConsumed { get; private set; }

        public void Consume(LaceExternalSourceConfigurationEventMessage message)
        {
            new PersistAggregate(new AggregateExternalSourcesConfiguration(message.Id, message.AggregateId,
                message.Source,
                message.Message,
                message.EventDate)).SaveAggregate();

            HasBeenConsumed = true;
        }
    }
}
