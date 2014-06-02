using EasyNetQ.AutoSubscribe;
using Monitoring.Modules.Lace.Messages;

namespace Monitoring.Modules.Lace.Consumers
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
