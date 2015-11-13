using System;
using System.Web.Caching;
using Common.Logging;
using EasyNetQ;
using EasyNetQ.Topology;
using Monitoring.Dashboard.UI.Core.Contracts.Services;
using Workflow.BuildingBlocks;

namespace Monitoring.Dashboard.UI.Infrastructure.Services
{
    public class DataProviderCommandPublisher : IPublishCacheMessages
    {
        private readonly IAdvancedBus _bus;
        private readonly IExchange _exchange;
        private readonly IQueue _queue;
        private readonly ILog _log;

        private const string Exchange = "DataPlatform.DataProvider.Cache.Receiver";
        private const string QueueName = "DataPlatform.DataProvider.Cache.Receiver";

        public DataProviderCommandPublisher(IAdvancedBus bus)
        {
            _bus = bus;
            _exchange = _bus.ExchangeDeclare(Exchange,
                ExchangeType.Fanout);
            _queue = _bus.QueueDeclare(QueueName);
            _bus.Bind(_exchange, _queue, "");
            _log = LogManager.GetLogger(GetType());
        }

        public void SendToBus<T>(T message) where T : class
        {
            try
            {
                _bus.Publish<T>(_exchange, "", true, false, new Message<T>(message));
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error sending message to Cache Queue: {0}", ex, ex.Message);
            }
        }
    }

    public static class QueueConfigurationReader
    {
        public static readonly CacheQueueConfiguration CacheSender;

        static QueueConfigurationReader()
        {
            CacheSender = new CacheQueueConfiguration();
        }
    }

    public class CacheQueueConfiguration : IDefineQueue
    {
        public string ConnectionStringKey
        {
            get { return "caching/dataprovider/queue"; }
        }

        public string ErrorExchangeName
        {
            get { return "DataPlatform.DataProvider.Cache.Receiver"; }
        }

        public string ErrorQueueName
        {
            get { return "DataPlatform.DataProvider.Cache.Receiver"; }
        }
        public string ExchangeType
        {
            get { return RabbitMQ.Client.ExchangeType.Fanout; }
        }
    }
}