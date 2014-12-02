using System;
using Lace.Shared.Monitoring.Messages.Commands;
using Lace.Shared.Monitoring.Messages.Core;

namespace Lace.Shared.Monitoring.Messages.Publisher
{
    internal static class CommandMessageFactory
    {
        internal static DataProviderCommand StartCallingDataProviderSource(Guid id, DataProvider dataProvider,
            string payload, Category category, string metadata, bool isJson)
        {
            return new DataProviderCommand(id, dataProvider,
                string.Format("Start Calling Data Provider {0}", dataProvider.ToString()), payload, metadata,
                DateTime.UtcNow,
                category, isJson);
        }

        internal static DataProviderCommand StopCallingDataProviderSource(Guid id, DataProvider dataProvider,
            string payload, Category category, string metadata, bool isJson)
        {
            return new DataProviderCommand(id, dataProvider,
                string.Format("Stop Calling Data Provider {0}", dataProvider.ToString()), payload, metadata,
                DateTime.UtcNow,
                category, isJson);
        }

        internal static DataProviderCommand StartDataProvider(Guid id, DataProvider dataProvider,
            string payload, Category category, string metadata, bool isJson)
        {
            return new DataProviderCommand(id, dataProvider,
                string.Format("Start Executing Data Provider {0}", dataProvider.ToString()), payload, metadata,
                DateTime.UtcNow,
                category, isJson);
        }

        internal static DataProviderCommand StopDataProvider(Guid id, DataProvider dataProvider,
            string payload, Category category, string metadata, bool isJson)
        {
            return new DataProviderCommand(id, dataProvider,
                string.Format("Stop Executing Data Provider {0}", dataProvider.ToString()), payload, metadata,
                DateTime.UtcNow,
                category, isJson);
        }

        internal static DataProviderFaultCommand FaultInDataProvider(Guid id, DataProvider dataProvider,
            string payload, Category category, string metadata, bool isJson)
        {
            return new DataProviderFaultCommand(id, dataProvider,
                string.Format("Error Occurred in Data Provider {0}", dataProvider.ToString()), payload, metadata,
                DateTime.UtcNow,
                category, isJson);
        }

        internal static DataProviderSecurityCommand SecurityFlagRaisedInDataProvider(Guid id, DataProvider dataProvider,
            string payload, Category category, string metadata, bool isJson)
        {
            return new DataProviderSecurityCommand(id, dataProvider,string.Format("Security flag raised in Data Provider {0}", dataProvider.ToString()),payload,metadata,DateTime.UtcNow,category,isJson);
        }

        internal static DataProviderConfigurationCommand ConfigurationInDataProvider(Guid id, DataProvider dataProvider,
            string payload, Category category, string metadata, bool isJson)
        {
            return new DataProviderConfigurationCommand(id, dataProvider,
                string.Format("Configuration in Data Provider {0}", dataProvider.ToString()), payload, metadata,
                DateTime.UtcNow, category, isJson);
        }

        internal static DataProviderTransformationCommand TransformationInDataProvider(Guid id, DataProvider dataProvider,
            string payload, Category category, string metadata, bool isJson)
        {
            return new DataProviderTransformationCommand(id, dataProvider,
                string.Format("Transformation in Data Provider {0}", dataProvider.ToString()), payload, metadata,
                DateTime.UtcNow, category, isJson);
        }
    }
}
