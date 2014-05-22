using EasyNetQ.AutoSubscribe;
using EventTracking.Modules.Lace.Messages;

namespace EventTracking.Modules.Lace.Consumers
{
    public class ExternalSourceTransformationConsumer : IConsume<LaceTransformResponseEventMessage>
    {
        public bool HasBeenConsumed { get; private set; }
        public void Consume(LaceTransformResponseEventMessage message)
        {
            HasBeenConsumed = true;
        }
    }
}
