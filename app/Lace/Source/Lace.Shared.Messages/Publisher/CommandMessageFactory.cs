using System;
using DataPlatform.Shared.Enums;
using Lace.Shared.Extensions;
using Lace.Shared.Monitoring.Messages.Commands;
using Lace.Shared.Monitoring.Messages.Core;

namespace Lace.Shared.Monitoring.Messages.Publisher
{
    public static class CommandMessageFactory
    {

        private static EventInDataProviderCommand GetCommand(Guid id, string payload, DateTime date)
        {
            return
                new EventInDataProviderCommand(new CommandDto(id, MonitoringSource.Lace,
                    payload, date));
        }

        public static EventInDataProviderCommand StartCallingDataProviderSource(Guid id,
            DataProviderCommandSource dataProvider,
            string payload, Category category, string metadata, bool isJson)
        {
            var command = new DataProviderCommand(id, dataProvider,
                string.Format("Start Calling Data Provider {0}", dataProvider.ToString()), payload, metadata,
                DateTime.UtcNow, category);

            return GetCommand(id, command.ObjectToJson(), command.Date);
        }

        public static EventInDataProviderCommand StopCallingDataProviderSource(Guid id, DataProviderCommandSource dataProvider,
            string payload, Category category, string metadata, bool isJson)
        {
            var command = new DataProviderCommand(id, dataProvider,
                string.Format("Stop Calling Data Provider {0}", dataProvider.ToString()), payload, metadata,
                DateTime.UtcNow,
                category);

            return GetCommand(id, command.ObjectToJson(), command.Date);
        }

        public static EventInDataProviderCommand StartDataProvider(Guid id, DataProviderCommandSource dataProvider,
            string payload, Category category, string metadata, bool isJson)
        {
            var command = new DataProviderCommand(id, dataProvider,
                string.Format("Start Executing Data Provider {0}", dataProvider.ToString()), payload, metadata,
                DateTime.UtcNow,
                category);

            return GetCommand(id, command.ObjectToJson(), command.Date);
        }

        public static EventInDataProviderCommand StopDataProvider(Guid id, DataProviderCommandSource dataProvider,
            string payload, Category category, string metadata, bool isJson)
        {
           var command = new DataProviderCommand(id, dataProvider,
                string.Format("Stop Executing Data Provider {0}", dataProvider.ToString()), payload, metadata,
                DateTime.UtcNow,
                category);

            return GetCommand(id, command.ObjectToJson(), command.Date);
        }

        public static EventInDataProviderCommand FaultInDataProvider(Guid id, DataProviderCommandSource dataProvider,
            string payload, Category category, string metadata, bool isJson)
        {
            var command = new DataProviderCommand(id, dataProvider,
                string.Format("Error Occurred in Data Provider {0}", dataProvider.ToString()), payload, metadata,
                DateTime.UtcNow,
                category);

            return GetCommand(id, command.ObjectToJson(), command.Date);
        }

        public static EventInDataProviderCommand SecurityFlagRaisedInDataProvider(Guid id,
            DataProviderCommandSource dataProvider,
            string payload, Category category, string metadata, bool isJson)
        {
            var command = new DataProviderCommand(id, dataProvider,
                    string.Format("Security flag raised in Data Provider {0}", dataProvider.ToString()), payload,
                    metadata, DateTime.UtcNow, category);

            return GetCommand(id, command.ObjectToJson(), command.Date);
        }

        public static EventInDataProviderCommand ConfigurationInDataProvider(Guid id,
            DataProviderCommandSource dataProvider,
            string payload, Category category, string metadata, bool isJson)
        {
            var command = new DataProviderCommand(id, dataProvider,
                    string.Format("Configuration in Data Provider {0}", dataProvider.ToString()), payload, metadata,
                    DateTime.UtcNow, category);

            return GetCommand(id, command.ObjectToJson(), command.Date);
        }

        public static EventInDataProviderCommand TransformationInDataProvider(Guid id,
            DataProviderCommandSource dataProvider,
            string payload, Category category, string metadata, bool isJson)
        {
           var command = new DataProviderCommand(id, dataProvider,
                string.Format("Transformation in Data Provider {0}", dataProvider.ToString()), payload, metadata,
                DateTime.UtcNow, category);

            return GetCommand(id, command.ObjectToJson(), command.Date);
        }
    }
}
