using EasyNetQ.AutoSubscribe;
using EventTracking.Modules.Lace.Messages;

namespace EventTracking.Modules.Lace.Consumers
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