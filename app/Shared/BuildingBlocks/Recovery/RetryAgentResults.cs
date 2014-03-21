using System;
using System.Collections.Generic;
using System.Linq;

namespace DataPlatform.BuildingBlocks.Recovery
{
    public class RetryAgentResults
    {
        private readonly List<RetryAgentResult> results = new List<RetryAgentResult>();

        public bool Succeeded
        {
            get { return results.Any(r => r.Success); }
        }

        public void AddResult(RetryAgentResult result)
        {
            results.Add(result);
        }

        public Exception FirstFailure()
        {
            return results.First().Exception;
        }
    }
}