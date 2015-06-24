using Workflow.BuildingBlocks;

namespace Workflow.Lace.Messages.Reader
{
    public static class ConfigurationReader
    {
        public static readonly WorkflowQueueConfiguration Workflow;
        public static readonly BillingQueueConfiguratoin Billing;
        public static readonly ReceiverQueueConfiguration Receiver;

        static ConfigurationReader()
        {
            Workflow = new WorkflowQueueConfiguration();
            Billing = new BillingQueueConfiguratoin();
            Receiver = new ReceiverQueueConfiguration();
        }
    }

    public class BillingQueueConfiguratoin : IDefineQueue
    {
        public string ConnectionStringKey
        {
            get { return "workflow/dataprovider/queue"; }
        }

        public string ErrorExchangeName
        {
            get { return "DataPlatform.Transactions.Billing.Error"; }
        }

        public string ErrorQueueName
        {
            get { return "DataPlatform.Transactions.Billing.Error"; }
        }
    }

    public class WorkflowQueueConfiguration : IDefineQueue
    {
        public string ConnectionStringKey
        {
            get { return "workflow/dataprovider/queue"; }
        }

        public string ErrorExchangeName
        {
            get { return "DataPlatform.DataProvider.Error"; }
        }

        public string ErrorQueueName
        {
            get { return "DataPlatform.DataProvider.Error"; }
        }
    }

    public class ReceiverQueueConfiguration : IDefineQueue
    {
        public string ConnectionStringKey
        {
            get { return "workflow/dataprovider/queue"; }
        }

        public string ErrorExchangeName
        {
            get { return "DataPlatform.DataProvider.Receiver.Error"; }
        }

        public string ErrorQueueName
        {
            get { return "DataPlatform.DataProvider.ReceiverError"; }
        }
    }
}
