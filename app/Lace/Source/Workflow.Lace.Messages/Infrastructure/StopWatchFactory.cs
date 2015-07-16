using System;
using DataPlatform.Shared.Enums;

namespace Workflow.Lace.Messages.Infrastructure
{
    public sealed class StopWatchFactory
    {
        public Func<DataProviderCommandSource, DataProviderStopWatch> StopWatchForDataProvider =
            provider => new DataProviderStopWatch(provider.ToString());
    }
}
