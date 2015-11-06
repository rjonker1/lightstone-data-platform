using System;
using System.Threading;
namespace Lim.Domain.Extensions
{

    public class RepeatAction
    {
        private readonly Func<bool> _condition;
        private TimeSpan _initialDelay = new TimeSpan(0);
        private int _maxAttempts;
        private TimeSpan _retry;

        public RepeatAction()
        {
            _retry = new TimeSpan(0, 0, 0, 5);
            _maxAttempts = 5;
        }

        private RepeatAction(Func<bool> condition)
        {
            this._condition = condition;
            _retry = new TimeSpan(0, 0, 0, 5);
            _maxAttempts = 5;
        }

        public static TimeSpan GetWaitTime()
        {
            return GetWaitTime(1, 5);
        }

        public static TimeSpan GetWaitTime(int minimumSeconds, int maximumSeconds)
        {
            return GenerateRandomDelay(minimumSeconds, maximumSeconds);
        }

        private static TimeSpan GenerateRandomDelay(int minimumSeconds, int maximumSeconds)
        {
            var random = new Random(DateTime.Now.Millisecond);

            var waitTime = random.Next(minimumSeconds, maximumSeconds).Seconds();
#if DEBUG
            waitTime = 0.Seconds();
#endif

            return waitTime;
        }

        public static RepeatAction While(Func<bool> func)
        {
            return new RepeatAction(func);
        }

        public RepeatAction RetryAfter(TimeSpan retry)
        {
            this._retry = retry;
            return this;
        }

        /// <summary>
        /// Default wait time is 5 seconds
        /// </summary>
        /// <returns></returns>
        public RepeatAction RetryAfter()
        {
            _retry = new TimeSpan(0, 0, 0, 5);
            return this;
        }

        public RepeatAction UpTo(RepeatValue repeatValue)
        {
            _maxAttempts = repeatValue.Times;
            return this;
        }

        /// <summary>
        /// Default retry is 5
        /// </summary>
        /// <returns></returns>
        public RepeatAction UpTo()
        {
            _maxAttempts = 5;
            return this;
        }

        public RepeatAction Debug()
        {
            return this;
        }

        public void Do(Action action)
        {
            Thread.Sleep(_initialDelay);

            var didRetry = false;

            var attempt = 0;
            while (_condition())
            {
                didRetry = true;

                attempt++;

                action();

                if (_condition())
                {
                    Thread.Sleep(_retry);
                }

                if (attempt >= _maxAttempts)
                {
                    break;
                }
            }
        }

        public RepeatAction WithInitialDelayOf(TimeSpan initialDelay)
        {
            this._initialDelay = initialDelay;
            return this;
        }
    }
}