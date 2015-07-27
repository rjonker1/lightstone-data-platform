namespace Recoveries.ErrorQueues.Integrations
{
    public class IntegrationSenderConfiguration: IErrorQueueConfiguration
    {
        public IntegrationSenderConfiguration()
        {
            Options = new QueueOptions("DataPlatform.Integration.Sender.Error", "localhost", "/", "guest", "guest", false, 10000,
                @"D:\DataplatformRecoveries\Integrations\");
        }
        public IQueueOptions Options { get; private set; }
    }
}
