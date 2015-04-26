using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Logging;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.Identifiers;
using EasyNetQ;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Shared.Extensions;
using Workflow.Lace.Domain;
using Workflow.Lace.Identifiers;
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

        public SendWorkflowCommands(IAdvancedBus bus, Guid requestId)
        {
            _requestId = requestId;
            _log = LogManager.GetLogger(GetType());
            _publisher = new WorkflowCommandPublisher(bus);
        }

        public void DataProviderRequest(DataProviderIdentifier dataProvider,
            ConnectionTypeIdentifier connection, object payload,
            DataProviderStopWatch stopWatch)
        {
            new SendRequestToDataProviderCommand(Guid.NewGuid(), _requestId,
                dataProvider,
                DateTime.UtcNow, connection,
                new PayloadIdentifier(new MetadataContainer().ObjectToJson(), payload.ObjectToJson(),
                    CommandDescriptions.StartExecutionDescription((DataProviderCommandSource) dataProvider.Id)))
                .SendToBus(_publisher, _log);
            stopWatch.Start();
        }


        public void DataProviderResponse(DataProviderIdentifier dataProvider,
            ConnectionTypeIdentifier connection, object payload,
            DataProviderStopWatch stopWatch)
        {
            stopWatch.Stop();

            new GetResponseFromDataProviderCommmand(Guid.NewGuid(), _requestId,
                dataProvider,
                DateTime.UtcNow, connection,
                new PayloadIdentifier(new PerformanceMetadata(stopWatch.ToObject()).ObjectToJson(),
                    payload.ObjectToJson(),
                    CommandDescriptions.EndExecutionDescription((DataProviderCommandSource) dataProvider.Id)))
                .SendToBus(_publisher, _log);
        }

        public void Begin(object payload, DataProviderStopWatch stopWatch, DataProviderCommandSource dataProvider)
        {
            new StartingCallCommand(Guid.NewGuid(), _requestId, CommandDescriptions.StartCallDescription(dataProvider),
                payload.ObjectToJson(), dataProvider, DateTime.UtcNow,
                new PerformanceMetadata(stopWatch.ToObject()).ObjectToJson(), Category.Performance).SendToBus(
                    _publisher, _log);
        }

        public void End(object payload, DataProviderStopWatch stopWatch, DataProviderCommandSource dataProvider)
        {
            new EndingCallCommand(Guid.NewGuid(), _requestId, CommandDescriptions.EndExecutionDescription(dataProvider),
                payload.ObjectToJson(), dataProvider, DateTime.UtcNow,
                new PerformanceMetadata(stopWatch.ToObject()).ObjectToJson(), Category.Performance).SendToBus(
                    _publisher, _log);
        }

        public void CreateTransaction(Guid packageId, long packageVersion, Guid userId, Guid requestId,
            Guid contractId, string system, long contractVersion, DataProviderState state, string accountNumber)
        {
            new CreateTransactionCommand(Guid.NewGuid(), packageId, packageVersion, DateTime.UtcNow, userId, requestId,
                contractId,
                system, contractVersion, state,accountNumber)
                .SendToBus(_publisher, _log);
        }

        public void EntryPointRequest(ICollection<IPointToLaceRequest> request, DataProviderStopWatch stopWatch)
        {
            new ReceiveEntryPointRequest(Guid.NewGuid(), _requestId, DateTime.UtcNow,
                SearchRequestIndentifier.GetSearchRequest(request),
                new PayloadIdentifier(new PerformanceMetadata(stopWatch.ToObject()).ObjectToJson(), request.ObjectToJson(),
                    CommandDescriptions.ReceiveEntryPointRequestDescription()))
                .SendToBus(_publisher, _log);
            stopWatch.Start();
        }

        public void EntryPointResponse(object payload, DataProviderStopWatch stopWatch, DataProviderState state, ICollection<IPointToLaceRequest> request)
        {
            stopWatch.Stop();
            new ReturnEntryPointResponse(Guid.NewGuid(), _requestId, DateTime.UtcNow,
                new StateIdentifier((int) state, state.ToString()),
                new PayloadIdentifier(new PerformanceMetadata(stopWatch.ToObject()).ObjectToJson(),
                    payload.ObjectToJson(),
                    CommandDescriptions.ReturnEntryPointResponseDescription()),SearchRequestIndentifier.GetSearchRequest(request))
                .SendToBus(_publisher, _log);

        }

        public void Send(CommandType commandType, object payload, object metadata,
            DataProviderCommandSource dataProvider)
        {
            Task.Run(() =>
            {
                switch (commandType)
                {
                    case CommandType.Fault:
                        Error(payload, new MetadataContainer(metadata), dataProvider);
                        break;
                    case CommandType.Configuration:
                        Configuring(payload, new MetadataContainer(metadata), dataProvider);
                        break;
                    case CommandType.Security:
                        Security(payload, new MetadataContainer(metadata), dataProvider);
                        break;
                    case CommandType.Transformation:
                        Transforming(payload, new MetadataContainer(metadata), dataProvider);
                        break;
                }
            });
        }

        private void Error(object payload, MetadataContainer metadata, DataProviderCommandSource dataProvider)
        {
            new ErrorInDataProviderCommand(Guid.NewGuid(), _requestId,
                CommandDescriptions.FaultDescription(dataProvider), payload.ObjectToJson(), dataProvider,
                DateTime.UtcNow, metadata.ObjectToJson(), Category.Fault)
                .SendToBus(_publisher, _log);
        }

        private void Transforming(object payload, MetadataContainer metadata, DataProviderCommandSource dataProvider)
        {
            new TransformingDataProviderResponseCommand(Guid.NewGuid(), _requestId,
                CommandDescriptions.TransformationDescription(dataProvider), payload.ObjectToJson(), dataProvider,
                DateTime.UtcNow, metadata.ObjectToJson(), Category.Configuration)
                .SendToBus(_publisher, _log);
        }

        private void Configuring(object payload, MetadataContainer metadata, DataProviderCommandSource dataProvider)
        {
            new ConfiguringDataProviderCommand(Guid.NewGuid(), _requestId,
                CommandDescriptions.ConfigurationDescription(dataProvider), payload.ObjectToJson(), dataProvider,
                DateTime.UtcNow, metadata.ObjectToJson(), Category.Configuration)
                .SendToBus(_publisher, _log);
        }

        private void Security(object payload, MetadataContainer metadata, DataProviderCommandSource dataProvider)
        {
            new RaisingSecurityFlagCommand(Guid.NewGuid(), _requestId,
                CommandDescriptions.SecurityDescription(dataProvider), payload.ObjectToJson(), dataProvider,
                DateTime.UtcNow, metadata.ObjectToJson(), Category.Security)
                .SendToBus(_publisher, _log);
        }
       
    }
}
