using EasyNetQ.AutoSubscribe;
using EventTracking.Modules.Lace.Messages;

namespace EventTracking.Modules.Lace.Consumers
{
    public class ExternalSourceNoResponseReceivedConsumer : IConsume<LaceExternalServiceNoResponseEventMessage>
    {
        public bool HasBeenConsumed { get; private set; }

        public void Consume(LaceExternalServiceNoResponseEventMessage message)
        {
            HasBeenConsumed = true;
        }
    }
}
