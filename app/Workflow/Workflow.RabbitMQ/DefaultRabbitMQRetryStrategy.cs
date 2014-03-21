using DataPlatform.BuildingBlocks.Extentions;
using DataPlatform.BuildingBlocks.Recovery.Strategies;

namespace Workflow.RabbitMQ
{
    public class DefaultRabbitMQRetryStrategy : RetryStrategy
    {
        public DefaultRabbitMQRetryStrategy() : base(2.Times(), 0.Seconds(), 1.Second())
        {
        }
    }
}