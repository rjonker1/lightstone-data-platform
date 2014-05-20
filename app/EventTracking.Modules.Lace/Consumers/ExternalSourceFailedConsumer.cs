using EasyNetQ.AutoSubscribe;
using EventTracking.Modules.Lace.Messages;

namespace EventTracking.Modules.Lace.Consumers
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
