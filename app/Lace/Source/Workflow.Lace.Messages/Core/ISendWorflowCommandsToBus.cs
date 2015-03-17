using System;
using DataPlatform.Shared.Enums;

namespace Workflow.Lace.Messages.Core
{
    public interface ISendWorkflowCommandsToBus
    {
        void RequestToDataProvider(DataProviderCommandSource dataProvider, string connectionType, string connection,
            DateTime date, DataProviderAction action, DataProviderState state);

        void ResponseFromDataProvider(DataProviderCommandSource dataProvider, string connectionType, string connection,
            DateTime date, DataProviderAction action, DataProviderState state);

        void CreateTransaction(Guid packageId, long packageVersion, DateTime date, Guid userId, Guid requestId,
            Guid contractId, string system, long contractVersion, DataProviderState state);

    }
}
