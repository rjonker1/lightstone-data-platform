namespace Recoveries.ErrorQueues.DataProviders
{
    public sealed class WorkflowSenderRecoveryConfiguration : IErrorQueueConfiguration
    {
        public WorkflowSenderRecoveryConfiguration()
        {
            Options = new QueueOptions("DataPlatform.DataProvider.Error", "localhost", "/", "guest", "guest", false, 10000,
                @"D:\DataplatformRecoveries\DataProviders\");
        }
        public IQueueOptions Options { get; private set; }
    }
}
