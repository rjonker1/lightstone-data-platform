using System;
using System.Collections.Generic;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Requests.Contracts;
using Workflow.Lace.Identifiers;
using Workflow.Lace.Messages.Core;
using Workflow.Lace.Messages.Infrastructure;

namespace Lace.Test.Helper.Builders.Buses
{
    public class WorkflowQueueSender
    {
        private ISendWorkflowCommand _workflow;
        private readonly DataProviderCommandSource _dataProvider;
        private DataProviderStopWatch _stopWatch;
        private DataProviderStopWatch _entryPointWatch;

        public WorkflowQueueSender(DataProviderCommandSource dataProvider)
        {
            _dataProvider = dataProvider;
            _stopWatch = new StopWatchFactory().StopWatchForDataProvider(dataProvider);
            _entryPointWatch = new StopWatchFactory().StopWatchForDataProvider(DataProviderCommandSource.EntryPoint);
        }

        public WorkflowQueueSender InitQueue(ISendWorkflowCommand workflow)
        {
            _workflow = workflow;
            return this;
        }


        public WorkflowQueueSender SendRequestToDataProvider(string connectionTpe,
            string connection, DataProviderAction action, DataProviderState state, object payload, decimal cost,
            decimal rsp)
        {
            _workflow.DataProviderRequest(
                new DataProviderIdentifier((int) _dataProvider, _dataProvider.ToString(), cost, rsp, action, state),
                new ConnectionTypeIdentifier(connection, connectionTpe), payload, _stopWatch);
            return this;
        }

        public WorkflowQueueSender ReceiveResponseFromDataProvider(string connectionTpe,
            string connection, DataProviderAction action, DataProviderState state, object payload, decimal cost,
            decimal rsp)
        {
            _workflow.DataProviderResponse(
                new DataProviderIdentifier((int) _dataProvider, _dataProvider.ToString(), cost, rsp, action, state),
                new ConnectionTypeIdentifier(connection, connectionTpe), payload, _stopWatch);
            return this;
        }

        public WorkflowQueueSender EntryPointRequest(ICollection<IPointToLaceRequest> request,
            DataProviderStopWatch watch)
        {
            _workflow.EntryPointRequest(request, _entryPointWatch);
            return this;
        }

        public WorkflowQueueSender EntryPointResponse(object payload, DataProviderState state,
            ICollection<IPointToLaceRequest> request, DataProviderStopWatch watch)
        {
            _workflow.EntryPointResponse(payload, watch,
                state, request);
            return this;
        }

        public WorkflowQueueSender Error()
        {
            _workflow.Send(CommandType.Fault, new Exception("An error occurred in the unit test").Message,
                new {ErrorMessage = string.Format("Error calling {0} Data Provider", _dataProvider.ToString())},
                _dataProvider);
            return this;
        }

        public WorkflowQueueSender Transformation(object payload, object metaData)
        {
            _workflow.Send(CommandType.Transformation, payload, metaData, _dataProvider);
            return this;
        }

        public WorkflowQueueSender Security(object payload, object metatadata)
        {
            _workflow.Send(CommandType.Security, payload, metatadata, _dataProvider);
            return this;
        }

        public WorkflowQueueSender Configuration(object payload, object metatdata)
        {
            _workflow.Send(CommandType.Configuration, payload, metatdata, _dataProvider);
            return this;
        }

        public WorkflowQueueSender CreateTransaction(Guid packageId, long packageVersion, Guid userId, Guid requestId,
            Guid contractId, string system, long contractVersion, DataProviderState state, string accountNumber)
        {
            _workflow.CreateTransaction(packageId, packageVersion, userId, requestId, contractId, system,
                contractVersion, state, accountNumber);
            return this;
        }

    }
}
