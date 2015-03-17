using System;
using DataPlatform.Shared.Enums;

namespace Workflow.Lace.Messages.Core
{
    public interface ISendWorkflowCommandsToBus
    {
        void SendRequestToDataProvider(DataProviderCommandSource dataProvider, string connectionType, string connection,
            DateTime date, DataProviderAction action, DataProviderState state);

        void ReceiveResponseFromDataProvider(DataProviderCommandSource dataProvider, string connectionType, string connection,
            DateTime date, DataProviderAction action, DataProviderState state);

    }
}
