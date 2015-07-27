namespace Recoveries.ErrorQueues.DataProviders
{
    public sealed class BillingRecoveryConfiguration : IErrorQueueConfiguration
    {
        public BillingRecoveryConfiguration()
        {
            Options = new QueueOptions("DataPlatform.Transactions.Billing.Error", "localhost", "/", "guest", "guest", false, 10000,
                @"D:\DataplatformRecoveries\DataProviders\");
        }

        public IQueueOptions Options { get; private set; }
    }
}
