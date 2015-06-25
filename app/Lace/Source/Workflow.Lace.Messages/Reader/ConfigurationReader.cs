using Workflow.BuildingBlocks;

namespace Workflow.Lace.Messages.Reader
{
    public static class ConfigurationReader
    {
        public static readonly WorkflowSenderQueueConfiguration WorkflowSender;
        public static readonly BillingQueueConfiguratoin Billing;
        public static readonly WorkflowReceiverQueueConfiguration WorkflowReceiver;

        static ConfigurationReader()
        {
            WorkflowSender = new WorkflowSenderQueueConfiguration();
            Billing = new BillingQueueConfiguratoin();
            WorkflowReceiver = new WorkflowReceiverQueueConfiguration();
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

        public string ExchangeName
        {
            get { return "DataPlatform.Transactions.Billing"; }
        }

        public string QueueName
        {
            get { return "DataPlatform.Transactions.Billing"; }
        }
    }

    public class WorkflowSenderQueueConfiguration : IDefineQueue
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


        public string ExchangeName
        {
            get { return "DataPlatform.DataProvider.Sender"; }
        }

        public string QueueName
        {
            get { return "DataPlatform.DataProvider.Sender"; }
        }
    }

    public class WorkflowReceiverQueueConfiguration : IDefineQueue
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
        public string ExchangeName
        {
            get { return "DataPlatform.DataProvider.Receiver"; }
        }

        public string QueueName
        {
            get { return "DataPlatform.DataProvider.Receiver"; }
        }
    }
}
