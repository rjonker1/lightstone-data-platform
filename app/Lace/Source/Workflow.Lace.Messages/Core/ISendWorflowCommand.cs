using System;
using System.Collections.Generic;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Requests.Contracts;
using Workflow.Lace.Domain;
using Workflow.Lace.Identifiers;
using Workflow.Lace.Messages.Infrastructure;

namespace Workflow.Lace.Messages.Core
{
    public interface ISendWorkflowCommand
    {
        void DataProviderRequest(DataProviderIdentifier dataProvider, ConnectionTypeIdentifier connection, object payload, DataProviderStopWatch stopWatch, string referenceNumber);
        void DataProviderResponse(DataProviderIdentifier dataProvider, ConnectionTypeIdentifier connection, object payload, DataProviderStopWatch stopWatch, string referenceNumber);
        void EntryPointRequest(ICollection<IPointToLaceRequest> request, DataProviderStopWatch stopWatch, DataProviderNoRecordState billNoRecords);
        void EntryPointResponse(object payload, DataProviderStopWatch stopWatch, DataProviderResponseState state, ICollection<IPointToLaceRequest> request, DataProviderNoRecordState billNoRecords);
        void CreateTransaction(Guid packageId, long packageVersion, Guid userId, Guid requestId,
            Guid contractId, string system, long contractVersion, DataProviderResponseState state, string accountNumber, double packageCostPrice, double packageRecommendedPrice, DataProviderNoRecordState billNoRecords);
        void Begin(object payload,DataProviderStopWatch stopWatch, DataProviderCommandSource dataProvider, DataProviderNoRecordState billNoRecords);
        void End(object payload,DataProviderStopWatch stopWatch, DataProviderCommandSource dataProvider, DataProviderNoRecordState billNoRecords);
        void Send(CommandType commandType, object payload, object metadata, DataProviderCommandSource dataProvider, DataProviderNoRecordState billNoRecords);

    }
}