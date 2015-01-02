﻿using System;
using System.Threading;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Shared;
using Monitoring.Queuing.Contracts;
using Monitoring.Test.Helper.Mothers;

namespace Monitoring.Test.Helper.Queues
{
    public class DataProviderQueueFunctions
    {
        private ISendMonitoringMessages _monitoring;
        private readonly string _request;
        private readonly DataProvider _dataProvider;
        private readonly IHaveQueueActions _actions;

        private DataProviderStopWatch _stopWatch;
        private DataProviderStopWatch _dataProviderStopWatch;

        private readonly Guid _aggregateId;

        public DataProviderQueueFunctions(string request, DataProvider dataProvider, IHaveQueueActions actions, Guid aggregateId)
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
            _monitoring = BusBuilder.ForMonitoringWriteMessages(_aggregateId);
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
            _monitoring.StartDataProvider(_dataProvider, _request, _dataProviderStopWatch);
            Thread.Sleep(1000);
            return this;
        }

        public DataProviderQueueFunctions ConfigurationMessage(string metadata)
        {
            _monitoring.DataProviderConfiguration(_dataProvider, _request, metadata);
            Thread.Sleep(1000);
            return this;
        }

        public DataProviderQueueFunctions SecurityMessage(string payload, string metadata)
        {
            _monitoring.DataProviderSecurity(_dataProvider, payload,
              metadata);
            Thread.Sleep(1000);
            return this;
        }

        public DataProviderQueueFunctions StartCallingMessage()
        {
            _monitoring.StartCallingDataProvider(_dataProvider, _request, _stopWatch);
            Thread.Sleep(1000);
            return this;
        }

        public DataProviderQueueFunctions FaultCallingMessage(string metatdata)
        {
            _monitoring.DataProviderFault(_dataProvider, _request,
                metatdata);
            Thread.Sleep(1000);
            return this;
        }

        public DataProviderQueueFunctions EndCallingMessage(string payload)
        {
            _monitoring.EndCallingDataProvider(_dataProvider, payload,
                _stopWatch);
            Thread.Sleep(1000);
            return this;
        }

        public DataProviderQueueFunctions TransformationMessage(string payload, string metaData)
        {
            _monitoring.DataProviderTransformation(_dataProvider, payload,
                metaData);
            Thread.Sleep(1000);
            return this;
        }

        public DataProviderQueueFunctions EndingDataProvider()
        {
            _monitoring.EndDataProvider(_dataProvider, _request, _dataProviderStopWatch);
            Thread.Sleep(1000);
            return this;
        }
    }
}
