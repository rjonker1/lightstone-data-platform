using System;
using Common.Logging;
using DataPlatform.Shared.Enums;
using NServiceBus;
using Workflow.Lace.Messages.Commands;
using Workflow.Lace.Messages.Core;
using Workflow.Lace.Messages.Extensions;

namespace Workflow.Lace.Messages.Shared
{
    public class SendWorkflowCommands : ISendWorkflowCommandsToBus
    {
        private readonly IPublishCommandMessages _publisher;
        private readonly ILog _log;
        private readonly Guid _requestId;

        public SendWorkflowCommands(IBus bus, Guid requestId)
        {
            _requestId = requestId;
            _log = LogManager.GetLogger(GetType());
            _publisher = new WorkflowCommandPublisher(bus, _log);
        }

        public void SendRequestToDataProvider(DataProviderCommandSource dataProvider,
            string connectionType,
            string connection, DateTime date, DataProviderAction action, DataProviderState state)
        {
            new SendRequestToDataProviderCommand(Guid.NewGuid(), _requestId, dataProvider, date,
                connectionType, connection, action, state).SendToBus(_publisher, _log);
        }


        public void ReceiveResponseFromDataProvider(DataProviderCommandSource dataProvider, string connectionType,
            string connection,
            DateTime date, DataProviderAction action, DataProviderState state)
        {
            new GetResponseFromDataProviderCommmand(Guid.NewGuid(), _requestId, dataProvider, date, connection,
                connectionType, state, action).SendToBus(
                    _publisher,
                    _log);
        }
    }
}
