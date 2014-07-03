using EasyNetQ.AutoSubscribe;
using Monitoring.Consumer.Lace.Persistence;
using Monitoring.Consumer.Lace.Aggregates;
using Monitoring.Consumer.Lace.Messages;

namespace Monitoring.Consumer.Lace.Consumers
{
    public class ExternalSourceExecutedConsumer : IConsume<LaceExternalSourceExecutionEventMessage>
    {
        public bool HasBeenConsumed { get; private set; }

        private readonly IPersistEvent _persistEvent;

        public ExternalSourceExecutedConsumer()
        {
            _persistEvent = new PersistEvent();
        }

        public void Consume(LaceExternalSourceExecutionEventMessage message)
        {
            _persistEvent
                .Save(new ExternalSourceExecution(message.Id, message.AggregateId, message.Source,
                    message.Message,
                    message.EventDate, message.Category));

            HasBeenConsumed = true;
        }
    }
}
