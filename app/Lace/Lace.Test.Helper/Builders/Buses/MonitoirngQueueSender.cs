using System;
using System.Threading;
using DataPlatform.Shared.Enums;
using Workflow.Lace.Messages.Core;
using Workflow.Lace.Messages.Infrastructure;

namespace Lace.Test.Helper.Builders.Buses
{
    public class MonitoirngQueueSender
    {
        private ISendCommandToBus _command;
        private IPublishCommandMessages _publisher;
        private readonly DataProviderCommandSource _dataProvider;

        private DataProviderStopWatch _stopWatch;
        private DataProviderStopWatch _dataProviderStopWatch;

        private readonly Guid _aggregateId;

        public MonitoirngQueueSender(DataProviderCommandSource dataProvider, Guid aggregateId)
        {
            _dataProvider = dataProvider;
            _aggregateId = aggregateId;
        }

        public MonitoirngQueueSender InitQueue(ISendCommandToBus command)
        {
            _command = command;
            return this;
        }

        public MonitoirngQueueSender InitStopWatch()
        {
            _stopWatch = new StopWatchFactory().StopWatchForDataProvider(_dataProvider);
            _dataProviderStopWatch = new StopWatchFactory().StopWatchForDataProvider(_dataProvider);
            Thread.Sleep(1000);
            return this;
        }

        public MonitoirngQueueSender StartingExecution(object message)
        {
            _command.Monitoring.Begin(message, _dataProviderStopWatch);
            Thread.Sleep(1000);
            return this;
        }

        public MonitoirngQueueSender Configuration(object message, object metadata)
        {
            _command.Monitoring.Send(CommandType.Configuration, message, metadata);
            Thread.Sleep(1000);
            return this;
        }

        public MonitoirngQueueSender Security(object message, object metadata)
        {
            _command.Monitoring.Send(CommandType.Security, message, metadata);
            Thread.Sleep(1000);
            return this;
        }

        public MonitoirngQueueSender StartCall(object message, object metadata)
        {
            _command.Monitoring.StartCall(message, _stopWatch);
            Thread.Sleep(1000);
            return this;
        }

        public MonitoirngQueueSender Error(object message, object metatdata)
        {
            _command.Monitoring.Send(CommandType.Fault, message, metatdata);
            Thread.Sleep(1000);
            return this;
        }

        public MonitoirngQueueSender EndCall(object message)
        {
            _command.Monitoring.EndCall(message, _stopWatch);
            Thread.Sleep(1000);
            return this;
        }

        public MonitoirngQueueSender Transform(object message, object metaData)
        {
            _command.Monitoring.Send(CommandType.Transformation, message, metaData);
            Thread.Sleep(1000);
            return this;
        }

        public MonitoirngQueueSender EndExecution(object message)
        {
            _command.Monitoring.End(message, _dataProviderStopWatch);
            Thread.Sleep(1000);
            return this;
        }
    }
}
