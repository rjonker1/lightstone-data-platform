using EasyNetQ.AutoSubscribe;
using EventTracking.Modules.Lace.Messages;

namespace EventTracking.Modules.Lace.Consumers
{
    public class ExternalSourceConsumer : IConsume<LaceExternalServiceEventMessage>
    {
        public bool HasBeenConsumed { get; private set; }
        public void Consume(LaceExternalServiceEventMessage message)
        {
            HasBeenConsumed = true;
        }
    }
}
