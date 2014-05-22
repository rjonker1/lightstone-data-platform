using EasyNetQ.AutoSubscribe;
using EventTracking.Modules.Lace.Messages;

namespace EventTracking.Modules.Lace.Consumers
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
