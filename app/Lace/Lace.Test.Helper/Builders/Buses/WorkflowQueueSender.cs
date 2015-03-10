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

        public WorkflowQueueSender ReceiveRequest(DateTime date)
        {
            _workflow.ReceiveRequest(_dataProvider, date);
            return this;
        }

        public WorkflowQueueSender SendRequestToDataProvider(DateTime date, object message, string connectionTpe,
            string connection)
        {
            _workflow.SendRequestToDataProvider(_dataProvider, message, connectionTpe, connection, date);
            return this;
        }

        public WorkflowQueueSender ReceiveResponseFromDataProvider(object message, DateTime date)
        {
            _workflow.ReceiveResponseFromDataProvider(_dataProvider,message,date);
            return this;
        }

        public WorkflowQueueSender ReturnResponse(DateTime date, object message)
        {
            _workflow.ReturnResponse(_dataProvider, date, message);
            return this;
        }
    }
}
