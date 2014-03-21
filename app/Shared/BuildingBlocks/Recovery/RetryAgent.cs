using System;
using System.Threading;
using Common.Logging;

namespace BuildingBlocks.Recovery
{
    public class RetryAgent
    {
        private static readonly ILog log = LogManager.GetLogger<RetryAgent>();
        private readonly IRetryStrategy strategy;
        private Action<Exception> exceptionHandler = e => log.ErrorFormat("Exception while retrying action. The exception was {0}", e);

        public RetryAgent(IRetryStrategy strategy)
        {
            this.strategy = strategy;
        }

        public RetryAgent OnException(Action<Exception> exceptionHandler)
        {
            this.exceptionHandler = exceptionHandler;
            return this;
        }

        public RetryAgentResults Execute(Action actionToRetry, Func<bool> successCondition)
        {
            var results = new RetryAgentResults();

            Thread.Sleep(strategy.InitialDelay.AsMilliSeconds);

            var done = false;
            do
            {
                strategy.Attempt();

                try
                {
                    actionToRetry();
                    done = strategy.Done(successCondition);
                    results.AddResult(new RetryAgentResult());
                }
                catch (Exception e)
                {
                    exceptionHandler(e);
                    done = strategy.Done();
                    results.AddResult(new RetryAgentResult(e));
                }

                if (!done)
                {
                    Thread.Sleep(strategy.Delay.AsMilliSeconds);
                }

            } while (!done);

            return results;
        }
    }
}