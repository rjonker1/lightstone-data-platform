using EasyNetQ.AutoSubscribe;
using Lace.Events;

namespace Lace.Tests.Data.Consumers
{
    public class LaceEventMessageConsumer : IConsume<ILaceEventMessage>
    {
        public bool WasInvoked { get; private set; }

        public void Consume(ILaceEventMessage message)
        {
            WasInvoked = true;
        }
    }
}
