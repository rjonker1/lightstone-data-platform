using System;
using DataPlatform.Shared.Enums;

namespace Workflow.Lace.Messages.Core
{
    public interface ISendWorkflowCommandsToBus
    {
        void ReceiveRequest(DataProviderCommandSource dataProvider, DateTime date);

        void SendRequestToDataProvider(DataProviderCommandSource dataProvider, dynamic payload,
            string connectionType, string connection, DateTime date);

        void ReceiveResponseFromDataProvider(DataProviderCommandSource dataProvider, dynamic payload,
            DateTime date);

        void ReturnResponse(DataProviderCommandSource dataProvider, DateTime date, dynamic payload);

    }
}
