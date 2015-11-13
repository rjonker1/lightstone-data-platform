using Recoveries.Core;
using Recoveries.Infrastructure.Configuration.DataProviders;
using Recoveries.Infrastructure.Configuration.Integrations;

namespace Recoveries.Infrastructure.Configuration
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
                new IntegrationSenderConfiguration(),
                new IntegrationReceiverConfiguration()
            };
        }
    }
}