using System;
using DataPlatform.Shared.Enums;
using PackageBuilder.Domain.Entities.DataProviders.ReadModels;
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
            _workflow.SendRequestToDataProvider(_dataProvider, connectionTpe, connection, date, action, state);
            return this;
        }

        public WorkflowQueueSender ReceiveResponseFromDataProvider(DateTime date, string connectionTpe,
            string connection, DataProviderAction action, DataProviderState state)
        {
            _workflow.ReceiveResponseFromDataProvider(_dataProvider, connectionTpe, connection, date, action, state);
            return this;
        }

    }
}
