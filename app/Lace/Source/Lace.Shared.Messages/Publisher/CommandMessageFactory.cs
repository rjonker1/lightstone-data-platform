using System;
using Lace.Shared.Monitoring.Messages.Commands;
using Lace.Shared.Monitoring.Messages.Core;

namespace Lace.Shared.Monitoring.Messages.Publisher
{
    internal static class CommandMessageFactory
    {
        internal static DataProviderWasCalledCommand StartCallingDataProviderSource(Guid id, DataProvider dataProvider,
            string payload, Category category, string metadata, bool isJson)
        {
            return new DataProviderWasCalledCommand(new DataProviderCommandDto(id, dataProvider,
                string.Format("Start Calling Data Provider {0}", dataProvider.ToString()), payload, metadata,
                DateTime.UtcNow,
                category, isJson));
        }

        internal static DataProviderHasEndedCommand StopCallingDataProviderSource(Guid id, DataProvider dataProvider,
            string payload, Category category, string metadata, bool isJson)
        {
            return new DataProviderHasEndedCommand(new DataProviderCommandDto(id, dataProvider,
                string.Format("Stop Calling Data Provider {0}", dataProvider.ToString()), payload, metadata,
                DateTime.UtcNow,
                category, isJson));
        }

        internal static DataProviderExecutingCommand StartDataProvider(Guid id, DataProvider dataProvider,
            string payload, Category category, string metadata, bool isJson)
        {
            return new DataProviderExecutingCommand(new DataProviderCommandDto(id, dataProvider,
                string.Format("Start Executing Data Provider {0}", dataProvider.ToString()), payload, metadata,
                DateTime.UtcNow,
                category, isJson));
        }

        internal static DataProviderHasExecutedCommand StopDataProvider(Guid id, DataProvider dataProvider,
            string payload, Category category, string metadata, bool isJson)
        {
            return new DataProviderHasExecutedCommand(new DataProviderCommandDto(id, dataProvider,
                string.Format("Stop Executing Data Provider {0}", dataProvider.ToString()), payload, metadata,
                DateTime.UtcNow,
                category, isJson));
        }

        internal static DataProviderHasFaultCommand FaultInDataProvider(Guid id, DataProvider dataProvider,
            string payload, Category category, string metadata, bool isJson)
        {
            return new DataProviderHasFaultCommand(new DataProviderCommandDto(id, dataProvider,
                string.Format("Error Occurred in Data Provider {0}", dataProvider.ToString()), payload, metadata,
                DateTime.UtcNow,
                category, isJson));
        }

        internal static DataProviderHasSecurityCommand SecurityFlagRaisedInDataProvider(Guid id,
            DataProvider dataProvider,
            string payload, Category category, string metadata, bool isJson)
        {
            return
                new DataProviderHasSecurityCommand(new DataProviderCommandDto(id, dataProvider,
                    string.Format("Security flag raised in Data Provider {0}", dataProvider.ToString()), payload,
                    metadata, DateTime.UtcNow, category, isJson));
        }

        internal static DataProviderHasBeenConfiguredCommand ConfigurationInDataProvider(Guid id,
            DataProvider dataProvider,
            string payload, Category category, string metadata, bool isJson)
        {
            return
                new DataProviderHasBeenConfiguredCommand(new DataProviderCommandDto(id, dataProvider,
                    string.Format("Configuration in Data Provider {0}", dataProvider.ToString()), payload, metadata,
                    DateTime.UtcNow, category, isJson));
        }

        internal static DataProviderResponseTransformedCommand TransformationInDataProvider(Guid id,
            DataProvider dataProvider,
            string payload, Category category, string metadata, bool isJson)
        {
            return new DataProviderResponseTransformedCommand(new DataProviderCommandDto(id, dataProvider,
                string.Format("Transformation in Data Provider {0}", dataProvider.ToString()), payload, metadata,
                DateTime.UtcNow, category, isJson));
        }
    }
}
