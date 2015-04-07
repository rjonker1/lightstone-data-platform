using System;
using DataPlatform.Shared.Enums;
using Workflow.Lace.Messages.Infrastructure;

namespace Workflow.Lace.Messages.Core
{
    public interface ISendWorkflowCommand
    {
        void DataProviderRequestTransaction(DataProviderCommandSource dataProvider, string connectionType,
            string connection, DataProviderAction action, DataProviderState state, object payload,
            DataProviderStopWatch stopWatch);

        void DataProviderResponseTransaction(DataProviderCommandSource dataProvider, string connectionType,
            string connection, DataProviderAction action, DataProviderState state, object payload,
            DataProviderStopWatch stopWatch);

        void CreateTransaction(Guid packageId, long packageVersion, Guid userId, Guid requestId,
            Guid contractId, string system, long contractVersion, DataProviderState state);

        void Send(CommandType commandType, dynamic payload, dynamic metadata);

    }

    public interface ISendMonitoringCommand
    {
        void Begin(dynamic payload,
            DataProviderStopWatch stopWatch);

        void End(dynamic payload,
            DataProviderStopWatch stopWatch);

        void StartCall(dynamic payload,
            DataProviderStopWatch stopWatch);

        void EndCall(dynamic payload,
            DataProviderStopWatch stopWatch);

        void Send(CommandType commandType, dynamic payload, dynamic metadata);
    }
}
