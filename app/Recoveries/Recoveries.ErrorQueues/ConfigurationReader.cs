using Recoveries.ErrorQueues.DataProviders;
using Recoveries.ErrorQueues.Integrations;

namespace Recoveries.ErrorQueues
{
    public static class ConfigurationReader
    {
        public static readonly IErrorQueueConfiguration[] Configurations;

        static ConfigurationReader()
        {
            Configurations = new IErrorQueueConfiguration[]
            {
                new WorkflowReceiverRecoveryConfiguration(),
                new WorkflowSenderRecoveryConfiguration(),
                new BillingRecoveryConfiguration(),
                new IntegrationSenderConfiguration()
            };
        }
    }
}