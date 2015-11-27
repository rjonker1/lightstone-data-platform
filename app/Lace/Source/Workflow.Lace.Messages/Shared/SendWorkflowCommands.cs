using System;
using System.Collections.Generic;
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
    public sealed class SendWorkflowCommands : ISendWorkflowCommand
    {
        private readonly IPublishCommandMessages _publisher;
        private static readonly ILog Log = LogManager.GetLogger<WorkflowCommandPublisher>();
        private readonly Guid _requestId;

        public SendWorkflowCommands(IAdvancedBus bus, Guid requestId)
        {
            _requestId = requestId;
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
                .SendToBus(_publisher, Log);
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
                .SendToBus(_publisher, Log);
        }

        public void Begin(object payload, DataProviderStopWatch stopWatch, DataProviderCommandSource dataProvider, DataProviderNoRecordState billNoRecords)
        {
            new StartingCallCommand(Guid.NewGuid(), _requestId, CommandDescriptions.StartCallDescription(dataProvider),
                payload.ObjectToJson(), dataProvider, DateTime.UtcNow,
                new PerformanceMetadata(stopWatch.ToObject()).ObjectToJson(), Category.Performance,billNoRecords).SendToBus(
                    _publisher, Log);
            stopWatch.Start();
        }

        public void End(object payload, DataProviderStopWatch stopWatch, DataProviderCommandSource dataProvider,DataProviderNoRecordState billNoRecords)
        {
            stopWatch.Stop();
            new EndingCallCommand(Guid.NewGuid(), _requestId, CommandDescriptions.EndExecutionDescription(dataProvider),
                payload.ObjectToJson(), dataProvider, DateTime.UtcNow,
                new PerformanceMetadata(stopWatch.ToObject()).ObjectToJson(), Category.Performance,billNoRecords).SendToBus(
                    _publisher, Log);
        }

        public void CreateTransaction(Guid packageId, long packageVersion, Guid userId, Guid requestId,
            Guid contractId, string system, long contractVersion, DataProviderResponseState state, string accountNumber, double packageCostPrice, double packageRecommendedPrice, DataProviderNoRecordState billNoRecords)
        {
            new CreateTransactionCommand(Guid.NewGuid(), packageId, packageVersion, DateTime.UtcNow, userId, requestId,
                contractId,
                system, contractVersion, state, accountNumber, packageCostPrice, packageRecommendedPrice, billNoRecords)
                .SendToBus(_publisher, Log);
        }

        public void EntryPointRequest(ICollection<IPointToLaceRequest> request, DataProviderStopWatch stopWatch, DataProviderNoRecordState billNoRecords)
        {
            new ReceiveEntryPointRequest(Guid.NewGuid(), _requestId, DateTime.UtcNow,
                SearchRequestIndentifier.Determine(request),
                new PayloadIdentifier(new PerformanceMetadata(stopWatch.ToObject()).ObjectToJson(), request.ObjectToJson(),
                    CommandDescriptions.ReceiveEntryPointRequestDescription()),new NoRecordBillableIdentifier((int)billNoRecords,billNoRecords.ToString()))
                .SendToBus(_publisher, Log);
            stopWatch.Start();
        }

        public void EntryPointResponse(object payload, DataProviderStopWatch stopWatch, DataProviderResponseState state, ICollection<IPointToLaceRequest> request, DataProviderNoRecordState billNoRecords)
        {
            stopWatch.Stop();
            new ReturnEntryPointResponse(Guid.NewGuid(), _requestId, DateTime.UtcNow,
                new StateIdentifier((int) state, state.ToString()),
                new PayloadIdentifier(new PerformanceMetadata(stopWatch.ToObject()).ObjectToJson(),
                    payload.ObjectToJson(),
                    CommandDescriptions.ReturnEntryPointResponseDescription()),SearchRequestIndentifier.Determine(request),new NoRecordBillableIdentifier((int)billNoRecords,billNoRecords.ToString()))
                .SendToBus(_publisher, Log);

        }

        public void Send(CommandType commandType, object payload, object metadata,
            DataProviderCommandSource dataProvider, DataProviderNoRecordState billNoRecords)
        {
            
                switch (commandType)
                {
                    case CommandType.Error:
                        Error(payload, new MetadataContainer(metadata), dataProvider, billNoRecords);
                        break;
                    case CommandType.Configuration:
                        Configuring(payload, new MetadataContainer(metadata), dataProvider, billNoRecords);
                        break;
                    case CommandType.Security:
                        Security(payload, new MetadataContainer(metadata), dataProvider, billNoRecords);
                        break;
                    case CommandType.Transformation:
                        Transforming(payload, new MetadataContainer(metadata), dataProvider, billNoRecords);
                        break;
                }
        }

        private void Error(object payload, MetadataContainer metadata, DataProviderCommandSource dataProvider, DataProviderNoRecordState billNoRecords)
        {
            new ErrorInDataProviderCommand(Guid.NewGuid(), _requestId,
                CommandDescriptions.FaultDescription(dataProvider), payload.ObjectToJson(), dataProvider,
                DateTime.UtcNow, metadata.ObjectToJson(), Category.Error,billNoRecords)
                .SendToBus(_publisher, Log);
        }

        private void Transforming(object payload, MetadataContainer metadata, DataProviderCommandSource dataProvider, DataProviderNoRecordState billNoRecords)
        {
            new TransformingDataProviderResponseCommand(Guid.NewGuid(), _requestId,
                CommandDescriptions.TransformationDescription(dataProvider), payload.ObjectToJson(), dataProvider,
                DateTime.UtcNow, metadata.ObjectToJson(), Category.Configuration,billNoRecords)
                .SendToBus(_publisher, Log);
        }

        private void Configuring(object payload, MetadataContainer metadata, DataProviderCommandSource dataProvider, DataProviderNoRecordState billNoRecords)
        {
            new ConfiguringDataProviderCommand(Guid.NewGuid(), _requestId,
                CommandDescriptions.ConfigurationDescription(dataProvider), payload.ObjectToJson(), dataProvider,
                DateTime.UtcNow, metadata.ObjectToJson(), Category.Configuration,billNoRecords)
                .SendToBus(_publisher, Log);
        }

        private void Security(object payload, MetadataContainer metadata, DataProviderCommandSource dataProvider, DataProviderNoRecordState billNoRecords)
        {
            new RaisingSecurityFlagCommand(Guid.NewGuid(), _requestId,
                CommandDescriptions.SecurityDescription(dataProvider), payload.ObjectToJson(), dataProvider,
                DateTime.UtcNow, metadata.ObjectToJson(), Category.Security,billNoRecords)
                .SendToBus(_publisher, Log);
        }
    }
}