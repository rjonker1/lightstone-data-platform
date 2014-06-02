using EasyNetQ.AutoSubscribe;
using Monitoring.Modules.Lace.Messages;

namespace Monitoring.Modules.Lace.Consumers
{
    public class ExternalSourceReceivedResponseConsumer : IConsume<LaceExternalServiceResponseEventMessage>
    {
        public bool HasBeenConsumed { get; private set; }

        public void Consume(LaceExternalServiceResponseEventMessage message)
        {
            HasBeenConsumed = true;
        }
    }
  
}
