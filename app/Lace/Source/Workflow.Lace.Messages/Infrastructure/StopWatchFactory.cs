using System;
using DataPlatform.Shared.Enums;

namespace Workflow.Lace.Messages.Infrastructure
{
    public class StopWatchFactory
    {
        public Func<DataProviderCommandSource, DataProviderStopWatch> StopWatchForDataProvider =
            provider => new DataProviderStopWatch(provider.ToString());
    }
}
