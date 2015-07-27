namespace Recoveries.ErrorQueues.DataProviders
{
    public sealed class WorkflowReceiverRecoveryConfiguration : IErrorQueueConfiguration
    {
        public WorkflowReceiverRecoveryConfiguration()
        {
            Options = new QueueOptions("DataPlatform.DataProvider.Receiver.Error", "localhost", "/", "guest", "guest", false, 10000,
                @"D:\DataplatformRecoveries\DataProviders\");
        }

        public IQueueOptions Options { get; private set; }
    }
}
