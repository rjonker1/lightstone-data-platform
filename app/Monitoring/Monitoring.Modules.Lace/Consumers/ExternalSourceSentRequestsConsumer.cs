using EasyNetQ.AutoSubscribe;
using Monitoring.Modules.Lace.AggregatePersistence;
using Monitoring.Modules.Lace.Aggregates;
using Monitoring.Modules.Lace.Messages;

namespace Monitoring.Modules.Lace.Consumers
{
    public class ExternalSourceSentRequestsConsumer : IConsume<LaceExternalSourceRequestEventMessage>
    {
        public bool HasBeenConsumed { get; private set; }

        public void Consume(LaceExternalSourceRequestEventMessage message)
        {
            new PersistAggregate(new AggregateExternalSourcesRequestsSent(message.Id, message.AggregateId,
                message.Source,
                message.Message,
                message.EventDate)).SaveAggregate();

            HasBeenConsumed = true;
        }
    }
}