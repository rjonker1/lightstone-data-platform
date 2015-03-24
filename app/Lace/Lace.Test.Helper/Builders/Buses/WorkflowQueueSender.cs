using System;
using DataPlatform.Shared.Enums;
using Workflow.Lace.Messages.Core;

namespace Lace.Test.Helper.Builders.Buses
{
    public class WorkflowQueueSender
    {
        private ISendWorkflowCommandsToBus _workflow;
        private readonly DataProviderCommandSource _dataProvider;

        public WorkflowQueueSender(DataProviderCommandSource dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public WorkflowQueueSender InitQueue(ISendWorkflowCommandsToBus workflow)
        {
            _workflow = workflow;
            return this;
        }


        public WorkflowQueueSender SendRequestToDataProvider(DateTime date, string connectionTpe,
            string connection, DataProviderAction action, DataProviderState state)
        {
            _workflow.RequestToDataProvider(_dataProvider, connectionTpe, connection, date, action, state);
            return this;
        }

        public WorkflowQueueSender ReceiveResponseFromDataProvider(DateTime date, string connectionTpe,
            string connection, DataProviderAction action, DataProviderState state)
        {
            _workflow.ResponseFromDataProvider(_dataProvider, connectionTpe, connection, date, action, state);
            return this;
        }

        public WorkflowQueueSender CreateTransaction(Guid packageId, long packageVersion, DateTime date, Guid userId, Guid requestId,
            Guid contractId, string system, long contractVersion, DataProviderState state)
        {
            _workflow.CreateTransaction(packageId, packageVersion, date, userId, requestId, contractId, system,
                contractVersion, state);
            return this;
        }

    }
}
