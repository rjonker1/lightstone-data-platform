using System;
using System.Threading;
using DataPlatform.Shared.Enums;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Infrastructure;
using Lace.Shared.Monitoring.Messages.Infrastructure.Factories;
using Lace.Shared.Monitoring.Messages.Publisher;
using Monitoring.Queuing.Contracts;
using Monitoring.Test.Helper.Builder.DataProviderEvents;
using Monitoring.Test.Helper.Mothers;

namespace Monitoring.Test.Helper.Queues
{
    public class DataProviderQueueFunctions
    {
        private ISendCommandsToBus _monitoring;
        private CommandPublisher _publisher;
        private readonly string _request;
        private readonly DataProviderCommandSource _dataProvider;
        private readonly IHaveQueueActions _actions;

        private DataProviderStopWatch _stopWatch;
        private DataProviderStopWatch _dataProviderStopWatch;

        private readonly Guid _aggregateId;

        public DataProviderQueueFunctions(string request, DataProviderCommandSource dataProvider, IHaveQueueActions actions, Guid aggregateId)
        { 
            _request = request;
            _dataProvider = dataProvider;
            _actions = actions;
            _aggregateId = aggregateId;
        }

        public DataProviderQueueFunctions TearDown()
        {
            _actions.DeleteAllQueues();
            _actions.DeleteAllExchanges();
            return this;
        }

        public DataProviderQueueFunctions Setup()
        {
            _actions.AddAllExchanges();
            _actions.AddAllQueues();
            return this;
        }

        public DataProviderQueueFunctions InitBus()
        {
            _monitoring = BusBuilder.ForIvidCommands(_aggregateId);
            return this;
        }

        public DataProviderQueueFunctions InitReadBus()
        {
            _publisher = BusBuilder.ForMonitoringReadMessages(_aggregateId);
            return this;
        }

        public DataProviderQueueFunctions InitStopWatch()
        {
            _stopWatch = new StopWatchFactory().StopWatchForDataProvider(_dataProvider);
            _dataProviderStopWatch = new StopWatchFactory().StopWatchForDataProvider(_dataProvider);
            Thread.Sleep(1000);
            return this;
        }

        public DataProviderQueueFunctions StartingDataProviderMessage()
        {
            _monitoring.Begin(_request, _dataProviderStopWatch);
            Thread.Sleep(1000);
            return this;
        }

        public DataProviderQueueFunctions ConfigurationMessage(string metadata)
        {
            _monitoring.Send(CommandType.Configuration, _request, metadata);
            Thread.Sleep(1000);
            return this;
        }

        public DataProviderQueueFunctions SecurityMessage(string payload, string metadata)
        {
            _monitoring.Send(CommandType.Security, _request, metadata);
            Thread.Sleep(1000);
            return this;
        }

        public DataProviderQueueFunctions StartCallingMessage()
        {
            _monitoring.StartCall(_request, _stopWatch);
            Thread.Sleep(1000);
            return this;
        }

        public DataProviderQueueFunctions FaultCallingMessage(string metatdata)
        {
            _monitoring.Send(CommandType.Fault, _request, metatdata);
            Thread.Sleep(1000);
            return this;
        }

        public DataProviderQueueFunctions EndCallingMessage(string payload)
        {
            _monitoring.EndCall(payload, _stopWatch);
            Thread.Sleep(1000);
            return this;
        }

        public DataProviderQueueFunctions TransformationMessage(string payload, string metaData)
        {
            _monitoring.Send(CommandType.Transformation, payload, metaData);
            Thread.Sleep(1000);
            return this;
        }

        public DataProviderQueueFunctions EndingDataProvider()
        {
            _monitoring.End(_request, _dataProviderStopWatch);
            Thread.Sleep(1000);
            return this;
        }

        //**************************
        //Events
        //**************************
        public DataProviderQueueFunctions DataProviderCallEndedEvent()
        {
            SendToBus(new DataProviderEvents().ForDataProviderEvent(_aggregateId, "{}", DateTime.Now));
            Thread.Sleep(1000);
            return this;
        }

        public DataProviderQueueFunctions DataProviderExecutingEvent()
        {
            SendToBus(new DataProviderEvents().ForDataProviderEvent(_aggregateId, "{}", DateTime.Now));
            Thread.Sleep(1000);
            return this;
        }

        public DataProviderQueueFunctions DataProviderHasConfigurationEvent()
        {
            SendToBus(new DataProviderEvents().ForDataProviderEvent(_aggregateId, "{}", DateTime.Now));
            Thread.Sleep(1000);
            return this;
        }

        public DataProviderQueueFunctions DataProviderHasExecutedEvent()
        {
            SendToBus(new DataProviderEvents().ForDataProviderEvent(_aggregateId, "{}", DateTime.Now));
            Thread.Sleep(1000);
            return this;
        }


        public DataProviderQueueFunctions DataProviderHasFaultEvent()
        {
            SendToBus(new DataProviderEvents().ForDataProviderEvent(_aggregateId, "{}", DateTime.Now));
            Thread.Sleep(1000); 
            return this;
        }

        public DataProviderQueueFunctions DataProviderHasSecurityEvent()
        {
            SendToBus(new DataProviderEvents().ForDataProviderEvent(_aggregateId, "{}", DateTime.Now));
            Thread.Sleep(1000);
            return this;
        }

        public DataProviderQueueFunctions DataProviderasBeenTransformedEvent()
        {
            SendToBus(new DataProviderEvents().ForDataProviderEvent(_aggregateId, "{}", DateTime.Now));
            Thread.Sleep(1000);
            return this;
        }

        public DataProviderQueueFunctions DataProviderIsCalledEvent()
        {
            SendToBus(new DataProviderEvents().ForDataProviderEvent(_aggregateId, "{}", DateTime.Now));
            Thread.Sleep(1000);
            return this;
        }

        private void SendToBus<T>(T message) where T : class
        {
            System.Threading.Tasks.Task.Run(() => SendMessagesAsync(message));
        }

        private void SendMessagesAsync<T>(T message) where T : class
        {
            _publisher.SendToBus(message);
        }
    }
}
