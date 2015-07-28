namespace Recoveries.ErrorQueues.DataProviders
{
    public sealed class WorkflowSenderRecoveryConfiguration : IErrorQueueConfiguration
    {
        public WorkflowSenderRecoveryConfiguration()
        {
            //Options = new QueueOptions("DataPlatform.DataProvider.Error", "localhost", "/", "guest", "guest", false, 10000,
            //    @"D:\DataplatformRecoveries\DataProviders\Sender");

            Options = new QueueOptions("DataPlatform.DataProvider.Sender", "localhost", "/", "guest", "guest", false, 10000,
                @"D:\DataplatformRecoveries\DataProviders\Sender", "DataPlatform.DataProvider.Error");
        }
        public IQueueOptions Options { get; private set; }
    }
}
