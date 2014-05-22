using EasyNetQ.AutoSubscribe;
using EventTracking.Modules.Lace.Messages;

namespace EventTracking.Modules.Lace.Consumers
{
    public class ExternalSourceConfigurationConsumer : IConsume<LaceExternalServiceConfigurationEventMessage>
    {
        public bool HasBeenConsumed { get; private set; }

        public void Consume(LaceExternalServiceConfigurationEventMessage message)
        {
            HasBeenConsumed = true;
        }
    }
}
