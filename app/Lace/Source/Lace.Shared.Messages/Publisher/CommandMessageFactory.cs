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
            var command = new
            {
                StartedCallingDataProviderSource = new
                {
                    StartedCallingDataProviderSource = new StartedCallingDataProviderSource(id, dataProvider,
                        string.Format("Start Calling Data Provider {0}", dataProvider.ToString()),
                        payload.JsonToObject(), metadata.JsonToObject(),
                        DateTime.UtcNow, category)
                }
            };

            return GetCommand(id, command.ObjectToJson(), DateTime.UtcNow);
        }

        public static MessageFromDataProvider StopCallingDataProviderSource(Guid id,
            DataProviderCommandSource dataProvider,
            string payload, Category category, string metadata, bool isJson)
        {
            var command = new
            {
                EndCallingDataProviderSource = new
                {
                    EndCallingDataProviderSource = new EndCallingDataProviderSource(id, dataProvider,
                        string.Format("Stop Calling Data Provider {0}", dataProvider.ToString()), payload.JsonToObject(), metadata.JsonToObject(),
                        DateTime.UtcNow,
                        category)
                }
            };

            return GetCommand(id, command.ObjectToJson(), DateTime.UtcNow);
        }

        public static MessageFromDataProvider StartDataProvider(Guid id, DataProviderCommandSource dataProvider,
            string payload, Category category, string metadata, bool isJson)
        {

            var command = new
            {
                StartDataProvider = new
                {
                    StartDataProvider = new StartDataProvider(id, dataProvider,
                        string.Format("Start Executing Data Provider {0}", dataProvider.ToString()),
                        payload.JsonToObject(), metadata.JsonToObject(),
                        DateTime.UtcNow,
                        category)
                }
            };

            return GetCommand(id, command.ObjectToJson(), DateTime.UtcNow);
        }

        public static MessageFromDataProvider StopDataProvider(Guid id, DataProviderCommandSource dataProvider,
            string payload, Category category, string metadata, bool isJson)
        {

            var command = new
            {
                EndDataProvider = new
                {
                    EndDataProvider = new EndDataProvider(id, dataProvider,
                        string.Format("Stop Executing Data Provider {0}", dataProvider.ToString()),
                        payload.JsonToObject(), metadata.JsonToObject(),
                        DateTime.UtcNow,
                        category)
                }
            };

            return GetCommand(id, command.ObjectToJson(), DateTime.UtcNow);
        }

        public static MessageFromDataProvider FaultInDataProvider(Guid id, DataProviderCommandSource dataProvider,
            string payload, Category category, string metadata, bool isJson)
        {
            var command = new
            {
                DataProviderHasFault = new
                {
                    DataProviderHasFault = new DataProviderHasFault(id, dataProvider,
                        string.Format("Error Occurred in Data Provider {0}", dataProvider.ToString()),
                        payload.JsonToObject(), metadata.JsonToObject(),
                        DateTime.UtcNow,
                        category)
                }
            };

            return GetCommand(id, command.ObjectToJson(), DateTime.UtcNow);
        }

        public static MessageFromDataProvider SecurityFlagRaisedInDataProvider(Guid id,
            DataProviderCommandSource dataProvider,
            string payload, Category category, string metadata, bool isJson)
        {
            var command = new
            {
                DataProviderSecurityFlag = new
                {
                    DataProviderSecurityFlag = new DataProviderSecurityFlag(id, dataProvider,
                        string.Format("Security flag raised in Data Provider {0}", dataProvider.ToString()),
                        payload.JsonToObject(),
                        metadata.JsonToObject(), DateTime.UtcNow, category)
                }
            };

            return GetCommand(id, command.ObjectToJson(), DateTime.UtcNow);
        }

        public static MessageFromDataProvider ConfigurationInDataProvider(Guid id,
            DataProviderCommandSource dataProvider,
            string payload, Category category, string metadata, bool isJson)
        {
            var command = new
            {
                DataProviderConfigured = new
                {
                    DataProviderConfigured = new DataProviderConfigured(id, dataProvider,
                        string.Format("Configuration in Data Provider {0}", dataProvider.ToString()),
                        payload.JsonToObject(), metadata.JsonToObject(),
                        DateTime.UtcNow, category)
                }
            };

            return GetCommand(id, command.ObjectToJson(), DateTime.UtcNow);
        }

        public static MessageFromDataProvider TransformationInDataProvider(Guid id,
            DataProviderCommandSource dataProvider,
            string payload, Category category, string metadata, bool isJson)
        {
            var command = new
            {
                DataProviderResponseTransformed = new
                {
                    DataProviderResponseTransformed = new DataProviderResponseTransformed(id, dataProvider,
                        string.Format("Transformation in Data Provider {0}", dataProvider.ToString()),
                        payload.JsonToObject(), metadata.JsonToObject(),
                        DateTime.UtcNow, category)
                }
            };

            return GetCommand(id, command.ObjectToJson(), DateTime.UtcNow);
        }
    }
}
