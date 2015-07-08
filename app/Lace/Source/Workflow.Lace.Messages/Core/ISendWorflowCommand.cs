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
        void DataProviderRequest(DataProviderIdentifier dataProvider,
            ConnectionTypeIdentifier connection, object payload,
            DataProviderStopWatch stopWatch);

        void DataProviderResponse(DataProviderIdentifier dataProvider,
            ConnectionTypeIdentifier connection, object payload,
            DataProviderStopWatch stopWatch);

        void EntryPointRequest(ICollection<IPointToLaceRequest> request, DataProviderStopWatch stopWatch);
        void EntryPointResponse(object payload, DataProviderStopWatch stopWatch, DataProviderState state, ICollection<IPointToLaceRequest> request);

        void CreateTransaction(Guid packageId, long packageVersion, Guid userId, Guid requestId,
            Guid contractId, string system, long contractVersion, DataProviderState state, string accountNumber, double packageCostPrice, double packageRecommendedPrice);

        void Begin(object payload,
            DataProviderStopWatch stopWatch, DataProviderCommandSource dataProvider);

        void End(object payload,
            DataProviderStopWatch stopWatch, DataProviderCommandSource dataProvider);

        void Send(CommandType commandType, object payload, object metadata,
            DataProviderCommandSource dataProvider);

    }
}
