namespace Recoveries.ErrorQueues.DataProviders
{
    public sealed class BillingRecoveryConfiguration : IErrorQueueConfiguration
    {
        public BillingRecoveryConfiguration()
        {
            Options = new QueueOptions("DataPlatform.Transactions.Billing", "localhost", "/", "guest", "guest", false, 10000,
                @"D:\DataplatformRecoveries\DataProviders\Billing", "DataPlatform.Transactions.Billing.Error");
        }

        public IQueueOptions Options { get; private set; }
    }
}
