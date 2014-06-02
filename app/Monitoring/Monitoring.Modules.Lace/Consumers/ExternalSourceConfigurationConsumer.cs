using EasyNetQ.AutoSubscribe;
using Monitoring.Modules.Lace.Messages;

namespace Monitoring.Modules.Lace.Consumers
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
