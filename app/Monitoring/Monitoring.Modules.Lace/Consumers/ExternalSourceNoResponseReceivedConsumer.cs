using EasyNetQ.AutoSubscribe;
using Monitoring.Modules.Lace.Messages;

namespace Monitoring.Modules.Lace.Consumers
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
