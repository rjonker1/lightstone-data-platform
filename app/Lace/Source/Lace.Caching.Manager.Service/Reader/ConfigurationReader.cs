using Workflow.BuildingBlocks;

namespace Lace.Caching.Manager.Service.Reader
{
    public class ConfigurationReader
    {
        public static readonly CacheQueueConfiguration Cache;
        static ConfigurationReader()
        {
            Cache = new CacheQueueConfiguration();
        }
    }

    public class CacheQueueConfiguration : IDefineQueue
    {
        public string ConnectionStringKey
        {
            get { return "workflow/dataprovider/queue"; }
        }

        public string ErrorExchangeName
        {
            get { return "DataPlatform.DataProvider.Cache.Error"; }
        }

        public string ErrorQueueName
        {
            get { return "DataPlatform.DataProvider.Cache.Error"; }
        }
        public string ExchangeType
        {
            get { return RabbitMQ.Client.ExchangeType.Fanout; }
        }
    }
}
