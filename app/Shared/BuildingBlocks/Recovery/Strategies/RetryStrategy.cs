using System;
using Shared.Fluency;

namespace Shared.Recovery.Strategies
{
    public abstract class RetryStrategy : IRetryStrategy
    {
        private readonly Counter counter;

        protected RetryStrategy(Times maxAttempts, Seconds initialDelay, Seconds delay)
        {
            InitialDelay = initialDelay;
            Delay = delay;
            counter = new Counter(maxAttempts.Count);
        }

        public Seconds InitialDelay { get; private set; }
        public Seconds Delay { get; private set; }

        public void Attempt()
        {
            counter.Increment();
        }

        public bool Done(Func<bool> successCondition)
        {
            return successCondition() && Done();
        }

        public bool Done()
        {
            return counter.Exceeded();
        }
    }
}