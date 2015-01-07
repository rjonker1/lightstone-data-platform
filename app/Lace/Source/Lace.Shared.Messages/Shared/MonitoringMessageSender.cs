using System;
using System.Threading.Tasks;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Publisher;
using NServiceBus;

namespace Lace.Shared.Monitoring.Messages.Shared
{
    public class MonitoringMessageSender : ISendMonitoringMessages
    {
        private readonly IMonitorDataProviderMessages _monitoring;
        private readonly ILog _log = LogManager.GetCurrentClassLogger();

        public Guid RequestId { get; private set; }

        public MonitoringMessageSender(IBus bus, Guid requestAggregateId)
        {
            _monitoring = new DataProviderMessagePublisher(bus);
            RequestId = requestAggregateId;
        }

        public void StartCallingDataProvider(DataProviderCommandSource dataProvider, string payload,
            DataProviderStopWatch stopWatch)
        {
            var command = CommandMessageFactory.StartCallingDataProviderSource(RequestId, dataProvider, payload,
                Category.Performance, "", true);
            SendToBus(command);
            stopWatch.Start();
        }

        public void EndCallingDataProvider(DataProviderCommandSource dataProvider, string payload,
            DataProviderStopWatch stopWatch)
        {
            stopWatch.Stop();
            var command = CommandMessageFactory.StopCallingDataProviderSource(RequestId, dataProvider, payload,
                Category.Performance, stopWatch.ToString(), true);
            SendToBus(command);
        }

        public void StartDataProvider(DataProviderCommandSource dataProvider, string payload, DataProviderStopWatch stopWatch)
        {
            var command = CommandMessageFactory.StartDataProvider(RequestId, dataProvider, payload,
                 Category.Performance, "", true);
            SendToBus(command);
            stopWatch.Start();
        }

        public void EndDataProvider(DataProviderCommandSource dataProvider, string payload, DataProviderStopWatch stopWatch)
        {
            stopWatch.Stop();
            var command = CommandMessageFactory.StopDataProvider(RequestId, dataProvider, payload,
                Category.Performance, stopWatch.ToString(), true);
            SendToBus(command);
        }

        public void DataProviderFault(DataProviderCommandSource dataProvider, string payload, string metadata)
        {
            var command = CommandMessageFactory.FaultInDataProvider(RequestId, dataProvider, payload, Category.Fault,
                metadata, true);
            SendToBus(command);
        }

        public void DataProviderSecurity(DataProviderCommandSource dataProvider, string payload, string metadata)
        {
            var command = CommandMessageFactory.SecurityFlagRaisedInDataProvider(RequestId, dataProvider, payload,
                Category.Security, metadata, true);
            SendToBus(command);
        }

        public void DataProviderConfiguration(DataProviderCommandSource dataProvider, string payload, string metadata)
        {
            var command = CommandMessageFactory.ConfigurationInDataProvider(RequestId, dataProvider, payload,
                Category.Configuration, metadata, true);
            SendToBus(command);
        }

        public void DataProviderTransformation(DataProviderCommandSource dataProvider, string payload, string metadata)
        {
            var command = CommandMessageFactory.TransformationInDataProvider(RequestId, dataProvider, payload,
                Category.Configuration, metadata, true);
            SendToBus(command);
        }

        private void SendToBus<T>(T message) where T : class
        {
            Task.Run(() => SendMessagesAsync(message));
        }

        private void SendMessagesAsync<T>(T message) where T : class
        {
            try
            {
                _monitoring.SendToBus(message);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error sending message to Data Provider Message Bus: {0}", ex.Message);
            }
        }


        
    }

    public interface ISendMonitoringMessages
    {
        Guid RequestId { get; }

        void StartCallingDataProvider(DataProviderCommandSource dataProvider, string payload,
            DataProviderStopWatch stopWatch);

        void EndCallingDataProvider(DataProviderCommandSource dataProvider, string payload,
            DataProviderStopWatch stopWatch);

        void StartDataProvider(DataProviderCommandSource dataProvider, string payload, DataProviderStopWatch stopWatch);

        void EndDataProvider(DataProviderCommandSource dataProvider, string payload, DataProviderStopWatch stopWatch);

        void DataProviderFault(DataProviderCommandSource dataProvider, string payload, string metadata);
        void DataProviderSecurity(DataProviderCommandSource dataProvider, string payload, string metadata);
        void DataProviderConfiguration(DataProviderCommandSource dataProvider, string payload, string metadata);
        void DataProviderTransformation(DataProviderCommandSource dataProvider, string payload, string metadata);
    }

    public class StopWatchFactory
    {
        public Func<DataProviderCommandSource, DataProviderStopWatch> StopWatchForDataProvider =
            provider => new DataProviderStopWatch(provider.ToString());
    }
}
