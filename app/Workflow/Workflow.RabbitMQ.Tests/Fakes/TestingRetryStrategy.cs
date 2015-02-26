using Shared.Extentions;
using Shared.Recovery.Strategies;

namespace Workflow.RabbitMQ.Tests.Fakes
{
    public class TestingRetryStrategy : RetryStrategy
    {
        public TestingRetryStrategy() : base(2.Times(), 0.Seconds(), 0.Seconds())
        {
        }
    }
}