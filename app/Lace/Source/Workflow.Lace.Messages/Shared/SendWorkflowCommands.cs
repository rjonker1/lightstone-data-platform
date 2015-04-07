using System;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.Shared.Extensions;
using NServiceBus;
using Workflow.Lace.Messages.Commands;
using Workflow.Lace.Messages.Core;
using Workflow.Lace.Messages.Extensions;
using Workflow.Lace.Messages.Infrastructure;

namespace Workflow.Lace.Messages.Shared
{
    public class SendWorkflowCommands : ISendWorkflowCommand
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

        public void DataProviderRequestTransaction(DataProviderCommandSource dataProvider,
            string connectionType,
            string connection, DataProviderAction action, DataProviderState state, object payload,
            DataProviderStopWatch stopWatch)
        {
            new SendRequestToDataProviderCommand(Guid.NewGuid(), _requestId, dataProvider, DateTime.UtcNow,
                connectionType, connection, action, state, new MetadataContainer().ObjectToJson(), payload.ObjectToJson(),
                CommandDescriptions.StartExecutionDescription(dataProvider))
                .SendToBus(_publisher, _log);
            stopWatch.Start();
        }


        public void DataProviderResponseTransaction(DataProviderCommandSource dataProvider, string connectionType,
            string connection, DataProviderAction action, DataProviderState state, object payload,
            DataProviderStopWatch stopWatch)
        {
            stopWatch.Stop();
            new GetResponseFromDataProviderCommmand(Guid.NewGuid(), _requestId, dataProvider, DateTime.UtcNow,
                connection,
                connectionType, state, action, new PerformanceMetadata(stopWatch.ToObject()).ObjectToJson(), payload.ObjectToJson(),
                CommandDescriptions.EndExecutionDescription(dataProvider))
                .SendToBus(
                    _publisher,
                    _log);
        }

        public void CreateTransaction(Guid packageId, long packageVersion, Guid userId, Guid requestId,
            Guid contractId, string system, long contractVersion, DataProviderState state)
        {
            new CreateTransactionCommand(Guid.NewGuid(), packageId, packageVersion, DateTime.UtcNow, userId, requestId,
                contractId,
                system, contractVersion, state)
                .SendToBus(_publisher, _log);
        }

        public void Send(CommandType commandType, dynamic payload, dynamic metadata)
        {
            throw new NotImplementedException();
        }
    }
}
