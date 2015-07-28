namespace Recoveries.ErrorQueues.DataProviders
{
    public sealed class WorkflowReceiverRecoveryConfiguration : IErrorQueueConfiguration
    {
        public WorkflowReceiverRecoveryConfiguration()
        {
            Options = new QueueOptions("DataPlatform.DataProvider.Receiver", "localhost", "/", "guest", "guest", false, 10000,
                @"D:\DataplatformRecoveries\DataProviders\Receiver", "DataPlatform.DataProvider.Receiver.Error");
        }

        public IQueueOptions Options { get; private set; }
    }
}
