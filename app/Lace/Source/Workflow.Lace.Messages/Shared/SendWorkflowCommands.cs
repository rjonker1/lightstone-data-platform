using System;
using Common.Logging;
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

        public void ReceiveRequest(DataPlatform.Shared.Enums.DataProviderCommandSource dataProvider,
            DateTime date)
        {
            new ReceiveRequestCommand(_requestId, dataProvider, date).SendToBus(_publisher, _log);
        }

        public void SendRequestToDataProvider(DataPlatform.Shared.Enums.DataProviderCommandSource dataProvider,
            dynamic payload, string connectionType,
            string connection, DateTime date)
        {
            new SendRequestToDataProviderCommand(Guid.NewGuid(), _requestId, dataProvider, new {payload}, date,
                connectionType, connection).SendToBus(_publisher, _log);
        }

        public void ReceiveResponseFromDataProvider(DataPlatform.Shared.Enums.DataProviderCommandSource dataProvider,
            dynamic payload, DateTime date)
        {
            new ReceiveResponseFromDataProviderCommand(Guid.NewGuid(), _requestId, dataProvider, date).SendToBus(
                _publisher, _log);
        }

        public void ReturnResponse(DataPlatform.Shared.Enums.DataProviderCommandSource dataProvider,
            DateTime date, dynamic payload)
        {
            new ReturnResponseCommmand(Guid.NewGuid(), _requestId, dataProvider, date).SendToBus(
                _publisher,
                _log);
        }
    }
}
