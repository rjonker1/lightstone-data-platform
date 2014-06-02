using EasyNetQ.AutoSubscribe;
using Monitoring.Modules.Lace.Messages;

namespace Monitoring.Modules.Lace.Consumers
{
    public class ExternalSourceSentRequestsConsumer : IConsume<LaceExternalServiceRequestEventMessage>
    {
        public bool HasBeenConsumed { get; private set; }

        public void Consume(LaceExternalServiceRequestEventMessage message)
        {
            HasBeenConsumed = true;
        }
    }
}