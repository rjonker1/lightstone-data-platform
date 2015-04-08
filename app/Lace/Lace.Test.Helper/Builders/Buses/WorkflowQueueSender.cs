using System;
using DataPlatform.Shared.Enums;
using Workflow.Lace.Messages.Core;
using Workflow.Lace.Messages.Infrastructure;

namespace Lace.Test.Helper.Builders.Buses
{
    public class WorkflowQueueSender
    {
        private ISendWorkflowCommand _workflow;
        private readonly DataProviderCommandSource _dataProvider;
        private DataProviderStopWatch _stopWatch;

        public WorkflowQueueSender(DataProviderCommandSource dataProvider)
        {
            _dataProvider = dataProvider;
            _stopWatch = new StopWatchFactory().StopWatchForDataProvider(dataProvider);
        }

        public WorkflowQueueSender InitQueue(ISendWorkflowCommand workflow)
        {
            _workflow = workflow;
            return this;
        }


        public WorkflowQueueSender SendRequestToDataProvider(string connectionTpe,
            string connection, DataProviderAction action, DataProviderState state, object payload)
        {
            _workflow.DataProviderRequest(_dataProvider, connectionTpe, connection, action, state,payload, _stopWatch);
            return this;
        }

        public WorkflowQueueSender ReceiveResponseFromDataProvider(string connectionTpe,
            string connection, DataProviderAction action, DataProviderState state, object payload)
        {
            _workflow.DataProviderResponse(_dataProvider, connectionTpe, connection, action, state, payload, _stopWatch);
            return this;
        }

        public WorkflowQueueSender CreateTransaction(Guid packageId, long packageVersion, Guid userId, Guid requestId,
            Guid contractId, string system, long contractVersion, DataProviderState state, string accountNumber)
        {
            _workflow.CreateTransaction(packageId, packageVersion, userId, requestId, contractId, system,
                contractVersion, state,accountNumber);
            return this;
        }

    }
}
