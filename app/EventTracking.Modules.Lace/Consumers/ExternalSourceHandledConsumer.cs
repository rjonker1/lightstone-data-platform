using EasyNetQ.AutoSubscribe;
using EventTracking.Modules.Lace.Messages;

namespace EventTracking.Modules.Lace.Consumers
{
    public class ExternalSourceHandledConsumer : IConsume<LaceSourceHandledEventMessage>
    {
        public bool HasBeenConsumed { get; private set; }

        public void Consume(LaceSourceHandledEventMessage message)
        {
            HasBeenConsumed = true;
        }
    }
}
