using System;
using DataPlatform.Shared.Enums;
using Lace.Shared.Extensions;
using Lace.Shared.Monitoring.Messages.Commands;
using Lace.Shared.Monitoring.Messages.Core;

namespace Lace.Shared.Monitoring.Messages.Publisher
{
    public static class CommandMessageFactory
    {

        private static MessageFromDataProvider GetCommand(Guid id, string payload, DateTime date)
        {
            return
                new MessageFromDataProvider(new CommandDto(id, MonitoringSource.Lace,
                    payload, date));
        }

        public static MessageFromDataProvider StartCallingDataProviderSource(Guid id,
            DataProviderCommandSource dataProvider,
            string payload, Category category, string metadata, bool isJson)
        {
            var command = new StartedCallingDataProviderSource(id, dataProvider,
                string.Format("Start Calling Data Provider {0}", dataProvider.ToString()), payload, metadata,
                DateTime.UtcNow, category);

            return GetCommand(id, command.ObjectToJson(), command.Date);
        }

        public static MessageFromDataProvider StopCallingDataProviderSource(Guid id, DataProviderCommandSource dataProvider,
            string payload, Category category, string metadata, bool isJson)
        {
            var command = new EndCallingDataProviderSource(id, dataProvider,
                string.Format("Stop Calling Data Provider {0}", dataProvider.ToString()), payload, metadata,
                DateTime.UtcNow,
                category);

            return GetCommand(id, command.ObjectToJson(), command.Date);
        }

        public static MessageFromDataProvider StartDataProvider(Guid id, DataProviderCommandSource dataProvider,
            string payload, Category category, string metadata, bool isJson)
        {
            var command = new StartDataProvider(id, dataProvider,
                string.Format("Start Executing Data Provider {0}", dataProvider.ToString()), payload, metadata,
                DateTime.UtcNow,
                category);

            return GetCommand(id, command.ObjectToJson(), command.Date);
        }

        public static MessageFromDataProvider StopDataProvider(Guid id, DataProviderCommandSource dataProvider,
            string payload, Category category, string metadata, bool isJson)
        {
            var command = new EndDataProvider(id, dataProvider,
                string.Format("Stop Executing Data Provider {0}", dataProvider.ToString()), payload, metadata,
                DateTime.UtcNow,
                category);

            return GetCommand(id, command.ObjectToJson(), command.Date);
        }

        public static MessageFromDataProvider FaultInDataProvider(Guid id, DataProviderCommandSource dataProvider,
            string payload, Category category, string metadata, bool isJson)
        {
            var command = new DataProviderHasFault(id, dataProvider,
                string.Format("Error Occurred in Data Provider {0}", dataProvider.ToString()), payload, metadata,
                DateTime.UtcNow,
                category);

            return GetCommand(id, command.ObjectToJson(), command.Date);
        }

        public static MessageFromDataProvider SecurityFlagRaisedInDataProvider(Guid id,
            DataProviderCommandSource dataProvider,
            string payload, Category category, string metadata, bool isJson)
        {
            var command = new DataProviderSecurityFlag(id, dataProvider,
                    string.Format("Security flag raised in Data Provider {0}", dataProvider.ToString()), payload,
                    metadata, DateTime.UtcNow, category);

            return GetCommand(id, command.ObjectToJson(), command.Date);
        }

        public static MessageFromDataProvider ConfigurationInDataProvider(Guid id,
            DataProviderCommandSource dataProvider,
            string payload, Category category, string metadata, bool isJson)
        {
            var command = new DataProviderConfigured(id, dataProvider,
                    string.Format("Configuration in Data Provider {0}", dataProvider.ToString()), payload, metadata,
                    DateTime.UtcNow, category);

            return GetCommand(id, command.ObjectToJson(), command.Date);
        }

        public static MessageFromDataProvider TransformationInDataProvider(Guid id,
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
