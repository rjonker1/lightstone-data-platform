using System;
using DataPlatform.Shared.Enums;
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

        void CreateTransaction(Guid packageId, long packageVersion, Guid userId, Guid requestId,
            Guid contractId, string system, long contractVersion, DataProviderState state, string accountNumber);

        void Begin(object payload,
            DataProviderStopWatch stopWatch, DataProviderCommandSource dataProvider);

        void End(object payload,
            DataProviderStopWatch stopWatch, DataProviderCommandSource dataProvider);

        void Send(CommandType commandType, object payload, object metadata,
            DataProviderCommandSource dataProvider);
        //void DataProviderRequest(DataProviderCommandSource dataProvider, string connectionType,
        //    string connection, DataProviderAction action, DataProviderState state, object payload,
        //    DataProviderStopWatch stopWatch, decimal costPrice, decimal recommendedPrice);

        //void DataProviderResponse(DataProviderCommandSource dataProvider, string connectionType,
        //    string connection, DataProviderAction action, DataProviderState state, object payload,
        //    DataProviderStopWatch stopWatch, decimal costPrice, decimal recommendedPrice);

        //void CreateTransaction(Guid packageId, long packageVersion, Guid userId, Guid requestId,
        //    Guid contractId, string system, long contractVersion, DataProviderState state, string accountNumber);

        //void Begin(object payload,
        //    DataProviderStopWatch stopWatch, DataProviderCommandSource dataProvider);

        //void End(object payload,
        //    DataProviderStopWatch stopWatch, DataProviderCommandSource dataProvider);

        //void Send(CommandType commandType, object payload, object metadata,
        //    DataProviderCommandSource dataProvider);

    }
}
