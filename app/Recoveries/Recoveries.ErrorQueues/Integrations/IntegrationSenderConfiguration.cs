namespace Recoveries.ErrorQueues.Integrations
{
    public class IntegrationSenderConfiguration: IErrorQueueConfiguration
    {
        public IntegrationSenderConfiguration()
        {
            Options = new QueueOptions("DataPlatform.Integration.Sender", "localhost", "/", "guest", "guest", false, 10000,
                @"D:\DataplatformRecoveries\Integrations\", "DataPlatform.Integration.Sender.Error");
        }
        public IQueueOptions Options { get; private set; }
    }
}
