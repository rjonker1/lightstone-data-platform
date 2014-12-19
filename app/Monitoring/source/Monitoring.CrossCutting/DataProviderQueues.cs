namespace Monitoring.CrossCutting
{
    public class DataProviderQueues
    {
        public static DataProviderQueue[] Names
        {
            get
            {
                return new[]
                {
                    new DataProviderQueue("DataPlatform.Monitoring.Host", "DataPlatform.Monitoring.Host",
                        string.Empty),
                    new DataProviderQueue("DataPlatform.Monitoring.Host.Retries",
                        "DataPlatform.Monitoring.Host.Retries", string.Empty),
                    new DataProviderQueue("DataPlatform.Monitoring.DenormalizerHost",
                        "DataPlatform.Monitoring.DenormalizerHost", string.Empty),
                    new DataProviderQueue("DataPlatform.Monitoring.DenormalizerHost.Retries",
                        "DataPlatform.Monitoring.DenormalizerHost.Retries", string.Empty),
                    new DataProviderQueue("DataPlatfrom.Monitoring.Read.Audit", "DataPlatfrom.Monitoring.Read.Audit",
                        string.Empty),
                    new DataProviderQueue("DataPlatform.Monitoring.Read.Error", "DataPlatform.Monitoring.Read.Error",
                        string.Empty),
                    new DataProviderQueue("DataPlatform.Monitoring.Write.Audit",
                        "DataPlatform.Monitoring.Write.Audit", string.Empty),
                    new DataProviderQueue("DataPlatform.Monitoring.Write.Error",
                        "DataPlatform.Monitoring.Write.Error", string.Empty)
                };
            }
        }

        public static DataProviderBindToQueue[] QueuesForBinding
        {
            get
            {
                return new[]
                {
                    //new DataProviderBindToQueue(
                    //    new DataProviderQueue("DataPlatform.Monitoring.DenormalizerHost",
                    //        "DataPlatform.Monitoring.DenormalizerHost",
                    //        string.Empty),
                    //    "DataPlatform.Monitoring.Host", "DataPlatform.Monitoring.Host",
                    //    string.Empty)
                    new DataProviderBindToQueue(
                        new DataProviderQueue("DataPlatform.Monitoring.Host",
                            "DataPlatform.Monitoring.Host",
                            string.Empty),
                        "DataPlatform.Monitoring.DenormalizerHost", "DataPlatform.Monitoring.DenormalizerHost",
                        string.Empty)
                };
            }
        }
    }

    public class DataProviderBindToQueue
    {
        public readonly DataProviderQueue BindToQueue;
        public readonly string QueueName;
        public readonly string ExchangeName;
        public readonly string RoutingKey;

        public DataProviderBindToQueue(DataProviderQueue bindToQueue, string queueName, string exchangeName, string routingKey)
        {
            BindToQueue = bindToQueue;
            QueueName = queueName;
            ExchangeName = exchangeName;
            RoutingKey = routingKey;
        }
    }

    public class DataProviderQueue
    {
        public readonly string Name;
        public readonly string Exchange;
        public readonly string RoutingKey;

        public DataProviderQueue(string name, string exchange, string routingKey)
        {
            Name = name;
            Exchange = exchange;
            RoutingKey = routingKey;
        }
    }
}
