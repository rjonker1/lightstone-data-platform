using System;
using System.Threading.Tasks;
using Common.Logging;
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

        public void StartCallingDataProvider(DataProvider dataProvider, string payload,
            DataProviderStopWatch stopWatch)
        {
            var command = CommandMessageFactory.StartCallingDataProviderSource(RequestId, dataProvider, payload,
                Category.Performance, "", true);
            SendToBus(command);
            stopWatch.Start();
        }

        public void EndCallingDataProvider(DataProvider dataProvider, string payload,
            DataProviderStopWatch stopWatch)
        {
            stopWatch.Stop();
            var command = CommandMessageFactory.StopCallingDataProviderSource(RequestId, dataProvider, payload,
                Category.Performance, stopWatch.ToString(), true);
            SendToBus(command);
        }

        public void StartDataProvider(DataProvider dataProvider, string payload, DataProviderStopWatch stopWatch)
        {
            var command = CommandMessageFactory.StartDataProvider(RequestId, dataProvider, payload,
                 Category.Performance, "", true);
            SendToBus(command);
            stopWatch.Start();
        }

        public void EndDataProvider(DataProvider dataProvider, string payload, DataProviderStopWatch stopWatch)
        {
            stopWatch.Stop();
            var command = CommandMessageFactory.StopDataProvider(RequestId, dataProvider, payload,
                Category.Performance, stopWatch.ToString(), true);
            SendToBus(command);
        }
       
        public void DataProviderFault(DataProvider dataProvider, string payload, string errorDetail)
        {
            var command = CommandMessageFactory.FaultInDataProvider(RequestId, dataProvider, payload, Category.Fault,
                errorDetail, true);
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

        void StartCallingDataProvider(DataProvider dataProvider, string payload,
            DataProviderStopWatch stopWatch);

        void EndCallingDataProvider(DataProvider dataProvider, string payload,
            DataProviderStopWatch stopWatch);

        void StartDataProvider(DataProvider dataProvider, string payload, DataProviderStopWatch stopWatch);

        void EndDataProvider(DataProvider dataProvider, string payload, DataProviderStopWatch stopWatch);

        void DataProviderFault(DataProvider dataProvider, string payload, string errorDetail);
    }

    public class StopWatchFactory
    {
        public Func<DataProvider, DataProviderStopWatch> StopWatchForDataProvider =
            provider => new DataProviderStopWatch(provider.ToString());
    }
}
