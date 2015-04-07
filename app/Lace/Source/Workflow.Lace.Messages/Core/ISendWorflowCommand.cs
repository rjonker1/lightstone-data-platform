using System;
using DataPlatform.Shared.Enums;
using Workflow.Lace.Messages.Infrastructure;

namespace Workflow.Lace.Messages.Core
{
    public interface ISendWorkflowCommand
    {
        void DataProviderRequestTransaction(DataProviderCommandSource dataProvider, string connectionType,
            string connection,
            DateTime date, DataProviderAction action, DataProviderState state);

        void DataProviderResponseTransaction(DataProviderCommandSource dataProvider, string connectionType,
            string connection,
            DateTime date, DataProviderAction action, DataProviderState state);

        void CreateTransaction(Guid packageId, long packageVersion, DateTime date, Guid userId, Guid requestId,
            Guid contractId, string system, long contractVersion, DataProviderState state);

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
