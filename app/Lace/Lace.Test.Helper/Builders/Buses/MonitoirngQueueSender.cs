using System;
using System.Threading;
using DataPlatform.Shared.Enums;
using Workflow.Lace.Domain;
using Workflow.Lace.Identifiers;
using Workflow.Lace.Messages.Core;
using Workflow.Lace.Messages.Infrastructure;

namespace Lace.Test.Helper.Builders.Buses
{
    public class MonitoirngQueueSender
    {
        private ISendCommandToBus _command;
        private IPublishCommandMessages _publisher;
        private readonly DataProviderCommandSource _dataProvider;
        private readonly DataProviderNoRecordState _billNoRecords;

        private DataProviderStopWatch _stopWatch;
        private DataProviderStopWatch _dataProviderStopWatch;

        private readonly Guid _aggregateId;

        public MonitoirngQueueSender(DataProviderCommandSource dataProvider, Guid aggregateId, DataProviderNoRecordState billNoRecords)
        {
            _dataProvider = dataProvider;
            _aggregateId = aggregateId;
            _billNoRecords = billNoRecords;
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
            _command.Workflow.Begin(message, _dataProviderStopWatch, _dataProvider, _billNoRecords);
            Thread.Sleep(1000);
            return this;
        }

        public MonitoirngQueueSender Configuration(object message, object metadata)
        {
            _command.Workflow.Send(CommandType.Configuration, message, metadata, _dataProvider, _billNoRecords);
            Thread.Sleep(1000);
            return this;
        }

        public MonitoirngQueueSender Security(object message, object metadata)
        {
            _command.Workflow.Send(CommandType.Security, message, metadata, _dataProvider, _billNoRecords);
            Thread.Sleep(1000);
            return this;
        }

        public MonitoirngQueueSender StartCall(object message, object metadata)
        {
            _command.Workflow.DataProviderRequest(
                new DataProviderIdentifier((int) _dataProvider, _dataProvider.ToString(), 55, 100,
                    DataProviderAction.Request, DataProviderResponseState.Successful, _billNoRecords),
                new ConnectionTypeIdentifier("TEST", "TEST"), new {message}, _stopWatch);
            Thread.Sleep(1000);
            return this;
        }

        public MonitoirngQueueSender Error(object message, object metatdata)
        {
            _command.Workflow.Send(CommandType.Error, message, metatdata, _dataProvider, _billNoRecords);
            Thread.Sleep(1000);
            return this;
        }

        public MonitoirngQueueSender EndCall(object message)
        {
            _command.Workflow.DataProviderRequest(
                new DataProviderIdentifier((int) _dataProvider, _dataProvider.ToString(), 55, 100,
                    DataProviderAction.Response, DataProviderResponseState.Successful, _billNoRecords),
                new ConnectionTypeIdentifier("TEST", "TEST"), new {message}, _stopWatch);
            Thread.Sleep(1000);
            return this;
        }

        public MonitoirngQueueSender Transform(object message, object metaData)
        {
            _command.Workflow.Send(CommandType.Transformation, message, metaData, _dataProvider, _billNoRecords);
            Thread.Sleep(1000);
            return this;
        }

        public MonitoirngQueueSender EndExecution(object message)
        {
            _command.Workflow.End(message, _dataProviderStopWatch, _dataProvider, _billNoRecords);
            Thread.Sleep(1000);
            return this;
        }
    }
}
