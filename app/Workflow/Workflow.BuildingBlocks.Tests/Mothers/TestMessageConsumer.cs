using EasyNetQ.AutoSubscribe;
using Workflow.BuildingBlocks.Tests.Fakes;

namespace Workflow.BuildingBlocks.Tests.Mothers
{
    public class TestMessageConsumer : IConsume<TestMessage>
    {
        public bool WasInvoked { get; private set; }

        public void Consume(TestMessage message)
        {
            WasInvoked = true;
        }
    }
}
