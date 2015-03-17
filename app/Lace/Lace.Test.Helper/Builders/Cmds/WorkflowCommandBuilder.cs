using System;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.Helpers;
using Lace.Test.Helper.Builders.Buses;

namespace Lace.Test.Helper.Builders.Cmds
{
    public class WorkflowCommandBuilder
    {
        private readonly Guid _requestId;

        public WorkflowCommandBuilder(Guid requestId)
        {
            _requestId = requestId;
        }

        public WorkflowCommandBuilder ForIvid()
        {
            var queue = new WorkflowQueueSender(DataProviderCommandSource.Ivid);
            queue.InitQueue(WorkflowBusBuilder.ForIvid(_requestId))
                .SendRequestToDataProvider(DateTime.Now, "Web Service",
                    "https://secure1.ubiquitech.co.za:443/ivid/ws/", DataProviderAction.Request,
                    DataProviderState.Successful)
                .ReceiveResponseFromDataProvider(DateTime.Now, "Web Service",
                    "https://secure1.ubiquitech.co.za:443/ivid/ws/", DataProviderAction.Request,
                    DataProviderState.Successful)
                .CreateTransaction(Guid.NewGuid(), 1, DateTime.Now, Guid.NewGuid(), _requestId, Guid.NewGuid(),
                    "API", 0, DataProviderState.Successful);
            return this;
        }
    }
}
