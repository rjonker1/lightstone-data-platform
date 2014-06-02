using EasyNetQ.AutoSubscribe;
using Monitoring.Modules.Lace.Messages;

namespace Monitoring.Modules.Lace.Consumers
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
