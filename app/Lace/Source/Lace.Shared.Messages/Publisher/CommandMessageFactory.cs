using System;
using Lace.Shared.Monitoring.Messages.Commands;
using Lace.Shared.Monitoring.Messages.Core;

namespace Lace.Shared.Monitoring.Messages.Publisher
{
    internal static class CommandMessageFactory
    {
        internal static ExecutingDataProviderCommand StartExecutingDataProvider(Guid id, DataProvider dataProvider,
            string payload, Category category, string metadata, bool isJson)
        {
            return new ExecutingDataProviderCommand(id, dataProvider,
                string.Format("Start Executing Data Provider {0}", dataProvider.ToString()), payload, metadata,
                DateTime.UtcNow,
                category, isJson);
        }

        internal static ExecutingDataProviderCommand StopExecutingDataProvider(Guid id, DataProvider dataProvider,
            string payload, Category category, string metadata, bool isJson)
        {
            return new ExecutingDataProviderCommand(id, dataProvider,
                string.Format("Stop Executing Data Provider {0}", dataProvider.ToString()), payload, metadata,
                DateTime.UtcNow,
                category, isJson);
        }

    }
}
