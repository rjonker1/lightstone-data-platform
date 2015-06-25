using Workflow.BuildingBlocks;

namespace Workflow.Lace.Messages.Reader
{
    public static class ConfigurationReader
    {
        public static readonly WorkflowSenderQueueConfiguration WorkflowSender;
        public static readonly BillingQueueConfiguration Billing;
        public static readonly WorkflowReceiverQueueConfiguration WorkflowReceiver;

        static ConfigurationReader()
        {
            WorkflowSender = new WorkflowSenderQueueConfiguration();
            Billing = new BillingQueueConfiguration();
            WorkflowReceiver = new WorkflowReceiverQueueConfiguration();
        }
    }

    public class BillingQueueConfiguration : IDefineQueue
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
        public string ExchangeType
        {
            get { return RabbitMQ.Client.ExchangeType.Fanout; }
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

        public string ExchangeType
        {
            get { return RabbitMQ.Client.ExchangeType.Fanout; }
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
        public string ExchangeType
        {
            get { return RabbitMQ.Client.ExchangeType.Fanout; }
        }
    }
}
