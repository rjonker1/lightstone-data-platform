using System;
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
                    ConfigureMonitoringWriteQueues.ForHost(),
                    ConfigureMonitoringWriteQueues.ForAudit(),
                    ConfigureMonitoringWriteQueues.ForErrors(),
                    ConfigureMonitoringWriteQueues.ForRetries(),

                    ConfigureMonitoringReadQueues.ForHost(),
                    ConfigureMonitoringReadQueues.ForAudit(),
                    ConfigureMonitoringReadQueues.ForErrors(),
                    ConfigureMonitoringReadQueues.ForRetries()

                };
            }
        }

        public static BindToQueue[] QueuesForBinding
        {
            get
            {
                return new[]
                {

                    new BindToQueue(ConfigureMonitoringWriteQueues.ForHost(),
                        ConfigureMonitoringReadQueues.ForHost().QueueName,
                        ConfigureMonitoringReadQueues.ForHost().ExchangeName,
                        ConfigureMonitoringReadQueues.ForHost().RoutingKey)

                    //new BindToQueue(
                    //    new MonitoringQueue("DataPlatform.Monitoring.Host",
                    //        "DataPlatform.Monitoring.Host",
                    //        string.Empty, ExchangeType.Fanout, QueueFunction.WriteQueue),
                    //    "DataPlatform.Monitoring.DenormalizerHost", "DataPlatform.Monitoring.DenormalizerHost",
                    //    string.Empty)
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
        public readonly QueueFunction QueueFunction;
        public readonly QueueType QueueType;

        public MonitoringQueue(string name, string exchangeName, string routingKey, string exchangeType,
            QueueFunction queueFunction, QueueType queueType)
        {
            QueueName = name;
            ExchangeName = exchangeName;
            RoutingKey = routingKey;
            ExchangeType = exchangeType;
            QueueFunction = queueFunction;
            QueueType = queueType;
        }
    }

    public enum QueueFunction
    {
        ReadQueue,
        WriteQueue
    }

    public enum QueueType
    {
        Host,
        Audit,
        Error,
        Retries
    }

    public class ConfigureMonitoringWriteQueues
    {
        public static Func<MonitoringQueue> ForHost =
            () => new MonitoringQueue("DataPlatform.Monitoring.Host", "DataPlatform.Monitoring.Host",
                string.Empty, ExchangeType.Fanout, QueueFunction.WriteQueue, QueueType.Host);

        public static Func<MonitoringQueue> ForAudit = () => new MonitoringQueue("DataPlatform.Monitoring.Write.Audit",
            "DataPlatform.Monitoring.Write.Audit", string.Empty, ExchangeType.Fanout, QueueFunction.WriteQueue,
            QueueType.Audit);

        public static Func<MonitoringQueue> ForErrors = () => new MonitoringQueue("DataPlatform.Monitoring.Write.Error",
            "DataPlatform.Monitoring.Write.Error", string.Empty, ExchangeType.Fanout, QueueFunction.WriteQueue,
            QueueType.Error);

        public static Func<MonitoringQueue> ForRetries =
            () => new MonitoringQueue("DataPlatform.Monitoring.Host.Retries",
                "DataPlatform.Monitoring.Host.Retries", string.Empty, ExchangeType.Fanout, QueueFunction.WriteQueue,
                QueueType.Retries);
    }

    public class ConfigureMonitoringReadQueues
    {
        public static Func<MonitoringQueue> ForHost =
            () => new MonitoringQueue("DataPlatform.Monitoring.DenormalizerHost",
                "DataPlatform.Monitoring.DenormalizerHost", string.Empty, ExchangeType.Fanout,
                QueueFunction.ReadQueue, QueueType.Host);

        public static Func<MonitoringQueue> ForAudit =
            () => new MonitoringQueue("DataPlatfrom.Monitoring.Read.Audit", "DataPlatfrom.Monitoring.Read.Audit",
                string.Empty, ExchangeType.Fanout, QueueFunction.ReadQueue, QueueType.Audit);

        public static Func<MonitoringQueue> ForErrors =
            () => new MonitoringQueue("DataPlatform.Monitoring.Read.Error", "DataPlatform.Monitoring.Read.Error",
                string.Empty, ExchangeType.Fanout, QueueFunction.ReadQueue, QueueType.Error);

        public static Func<MonitoringQueue> ForRetries =
            () => new MonitoringQueue("DataPlatform.Monitoring.DenormalizerHost.Retries",
                "DataPlatform.Monitoring.DenormalizerHost.Retries", string.Empty, ExchangeType.Fanout,
                QueueFunction.ReadQueue, QueueType.Retries);
    }
}
