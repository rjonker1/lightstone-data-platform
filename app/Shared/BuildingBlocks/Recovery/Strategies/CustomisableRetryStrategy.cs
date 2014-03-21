using DataPlatform.BuildingBlocks.Fluency;

namespace DataPlatform.BuildingBlocks.Recovery.Strategies
{
    public class CustomisableRetryStrategy : RetryStrategy
    {
        public CustomisableRetryStrategy(Times maxAttempts, Seconds initialDelay, Seconds delay)
            : base(maxAttempts, initialDelay, delay)
        {
        }
    }
}