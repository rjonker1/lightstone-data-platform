using System;

namespace DataPlatform.BuildingBlocks.Recovery
{
    public class RetryAgentResult
    {
        public RetryAgentResult()
        {
        }

        public RetryAgentResult(Exception exception)
        {
            Exception = exception;
        }

        public Exception Exception { get; private set; }

        public bool Success
        {
            get { return Exception == null; }
        }
    }
}