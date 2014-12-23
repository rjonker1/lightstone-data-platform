using RabbitMQ.Client;

namespace Monitoring.Queuing.Configuration
{
    public class MonitoringQueues
    {
        public static MonitoringQueue[] Names
        {
            get
            {
                return new[]
                {
                    new MonitoringQueue("DataPlatform.Monitoring.Host", "DataPlatform.Monitoring.Host",
                        string.Empty, ExchangeType.Fanout, QueueType.WriteQueue),
                    new MonitoringQueue("DataPlatform.Monitoring.Host.Retries",
                        "DataPlatform.Monitoring.Host.Retries", string.Empty, ExchangeType.Fanout, QueueType.WriteQueue),
                    new MonitoringQueue("DataPlatform.Monitoring.DenormalizerHost",
                        "DataPlatform.Monitoring.DenormalizerHost", string.Empty, ExchangeType.Fanout,
                        QueueType.ReadQueue),
                    new MonitoringQueue("DataPlatform.Monitoring.DenormalizerHost.Retries",
                        "DataPlatform.Monitoring.DenormalizerHost.Retries", string.Empty, ExchangeType.Fanout,
                        QueueType.ReadQueue),
                    new MonitoringQueue("DataPlatfrom.Monitoring.Read.Audit", "DataPlatfrom.Monitoring.Read.Audit",
                        string.Empty, ExchangeType.Fanout, QueueType.ReadQueue),
                    new MonitoringQueue("DataPlatform.Monitoring.Read.Error", "DataPlatform.Monitoring.Read.Error",
                        string.Empty, ExchangeType.Fanout, QueueType.ReadQueue),
                    new MonitoringQueue("DataPlatform.Monitoring.Write.Audit",
                        "DataPlatform.Monitoring.Write.Audit", string.Empty, ExchangeType.Fanout, QueueType.WriteQueue),
                    new MonitoringQueue("DataPlatform.Monitoring.Write.Error",
                        "DataPlatform.Monitoring.Write.Error", string.Empty, ExchangeType.Fanout, QueueType.WriteQueue)
                };
            }
        }

        public static BindToQueue[] QueuesForBinding
        {
            get
            {
                return new[]
                {
                    new BindToQueue(
                        new MonitoringQueue("DataPlatform.Monitoring.Host",
                            "DataPlatform.Monitoring.Host",
                            string.Empty, ExchangeType.Fanout, QueueType.WriteQueue),
                        "DataPlatform.Monitoring.DenormalizerHost", "DataPlatform.Monitoring.DenormalizerHost",
                        string.Empty)
                };
            }
        }
    }

    public class BindToQueue
    {
        public readonly MonitoringQueue Queue;
        public readonly string QueueName;
        public readonly string ExchangeName;
        public readonly string RoutingKey;

        public BindToQueue(MonitoringQueue bindToQueue, string queueName, string exchangeName, string routingKey)
        {
            Queue = bindToQueue;
            QueueName = queueName;
            ExchangeName = exchangeName;
            RoutingKey = routingKey;
        }
    }

    public class MonitoringQueue
    {
        public readonly string QueueName;
        public readonly string ExchangeName;
        public readonly string RoutingKey;
        public readonly string ExchangeType;
        public readonly QueueType QueueType;

        public MonitoringQueue(string name, string exchangeName, string routingKey, string exchangeType, QueueType queueType)
        {
            QueueName = name;
            ExchangeName = exchangeName;
            RoutingKey = routingKey;
            ExchangeType = exchangeType;
            QueueType = queueType;
        }
    }

    public enum QueueType
    {
        ReadQueue,
        WriteQueue
    }
}
