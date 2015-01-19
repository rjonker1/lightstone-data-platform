using System;
using DataPlatform.Shared.Enums;

namespace Lace.Shared.Monitoring.Messages.Infrastructure.Factories
{
    public class StopWatchFactory
    {
        public Func<DataProviderCommandSource, DataProviderStopWatch> StopWatchForDataProvider =
            provider => new DataProviderStopWatch(provider.ToString());
    }
}
