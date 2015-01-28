using System;
using System.Threading;
using DataPlatform.Shared.Enums;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Infrastructure;
using Lace.Shared.Monitoring.Messages.Infrastructure.Factories;
using Lace.Shared.Monitoring.Messages.Publisher;

namespace Lace.Test.Helper.Builders.Buses
{
    public class QueueSender
    {
        private ISendCommandsToBus _monitoring;
        private CommandPublisher _publisher;
        private readonly DataProviderCommandSource _dataProvider;

        private DataProviderStopWatch _stopWatch;
        private DataProviderStopWatch _dataProviderStopWatch;

        private readonly Guid _aggregateId;

        public QueueSender(DataProviderCommandSource dataProvider, Guid aggregateId)
        {
            _dataProvider = dataProvider;
            _aggregateId = aggregateId;
        }

        public QueueSender InitQueue(ISendCommandsToBus monitoring)
        {
            _monitoring = monitoring;
            return this;
        }

        public QueueSender InitStopWatch()
        {
            _stopWatch = new StopWatchFactory().StopWatchForDataProvider(_dataProvider);
            _dataProviderStopWatch = new StopWatchFactory().StopWatchForDataProvider(_dataProvider);
            Thread.Sleep(1000);
            return this;
        }

        public QueueSender StartingExecution(object message)
        {
            _monitoring.Begin(message, _dataProviderStopWatch);
            Thread.Sleep(1000);
            return this;
        }

        public QueueSender Configuration(object message, object metadata)
        {
            _monitoring.Send(CommandType.Configuration, message, metadata);
            Thread.Sleep(1000);
            return this;
        }

        public QueueSender Security(object message, object metadata)
        {
            _monitoring.Send(CommandType.Security, message, metadata);
            Thread.Sleep(1000);
            return this;
        }

        public QueueSender StartCall(object message, object metadata)
        {
            _monitoring.StartCall(message, _stopWatch);
            Thread.Sleep(1000);
            return this;
        }

        public QueueSender Error(object message, object metatdata)
        {
            _monitoring.Send(CommandType.Fault, message, metatdata);
            Thread.Sleep(1000);
            return this;
        }

        public QueueSender EndCall(object message)
        {
            _monitoring.EndCall(message, _stopWatch);
            Thread.Sleep(1000);
            return this;
        }

        public QueueSender Transform(object message, object metaData)
        {
            _monitoring.Send(CommandType.Transformation, message, metaData);
            Thread.Sleep(1000);
            return this;
        }

        public QueueSender EndExecution(object message)
        {
            _monitoring.End(message, _dataProviderStopWatch);
            Thread.Sleep(1000);
            return this;
        }
    }
}
