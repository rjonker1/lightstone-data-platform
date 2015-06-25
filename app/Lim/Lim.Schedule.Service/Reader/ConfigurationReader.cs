using Workflow.BuildingBlocks;

namespace Lim.Schedule.Service.Reader
{
    public class ConfigurationReader
    {
        public static readonly LimSenderQueueConfiguration LimSender;
        public static readonly LimReceiverQueueConfiguration LimReceiver;
        static ConfigurationReader()
        {
            LimSender = new LimSenderQueueConfiguration();
            LimReceiver = new LimReceiverQueueConfiguration();
        }
    }

    public class LimSenderQueueConfiguration : IDefineQueue
    {
        public string ConnectionStringKey
        {
            get { return "lim/schedule/bus"; }
        }

        public string ErrorExchangeName
        {
            get { return "DataPlatform.Integration.Sender.Error"; }
        }

        public string ErrorQueueName
        {
            get { return "DataPlatform.Integration.Sender.Error"; }
        }
        public string ExchangeType
        {
            get { return RabbitMQ.Client.ExchangeType.Fanout; }
        }
    }

    public class LimReceiverQueueConfiguration : IDefineQueue
    {
        public string ConnectionStringKey
        {
            get { return "lim/schedule/bus"; }
        }

        public string ErrorExchangeName
        {
            get { return "DataPlatform.Integration.Receiver.Error"; }
        }

        public string ErrorQueueName
        {
            get { return "DataPlatform.Integration.Receiver.Error"; }
        }
        public string ExchangeType
        {
            get { return RabbitMQ.Client.ExchangeType.Fanout; }
        }
    }
}
