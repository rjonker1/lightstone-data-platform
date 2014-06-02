using EasyNetQ.AutoSubscribe;
using Monitoring.Modules.Lace.Messages;

namespace Monitoring.Modules.Lace.Consumers
{
    public class ExternalSourceFailedConsumer : IConsume<LaceExternalServiceFailedEventMessage>
    {
        public bool HasBeenConsumed { get; private set; }

        public void Consume(LaceExternalServiceFailedEventMessage message)
        {
            HasBeenConsumed = true;
        }
    }
}
