using EasyNetQ.AutoSubscribe;
using Lace.Events.Messages;

namespace Lace.Events.Tests.Consumers
{
    public class LaceEventMessageConsumer : IConsume<LaceEventMessage>
    {
        public bool WasInvoked { get; private set; }

        public void Consume(LaceEventMessage message)
        {
            WasInvoked = true;
        }
    }
}
