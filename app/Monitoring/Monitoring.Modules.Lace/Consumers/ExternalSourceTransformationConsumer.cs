using EasyNetQ.AutoSubscribe;
using Monitoring.Modules.Lace.Messages;

namespace Monitoring.Modules.Lace.Consumers
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
