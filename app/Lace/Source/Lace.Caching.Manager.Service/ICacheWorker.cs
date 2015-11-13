using System.Collections.Specialized;
using Castle.Windsor;
using Common.Logging;
using EasyNetQ;
using EasyNetQ.Topology;
using Lace.Caching.Manager.Service.Jobs;
using Lace.Caching.Manager.Service.Receiver;
using Lace.Caching.Messages;
using Quartz;
using Quartz.Impl;

namespace Lace.Caching.Manager.Service
{
    public interface ICacheWorker
    {
        void Start();
        void End();
    }

    public class CacheWorker : ICacheWorker
    {
        private IAdvancedBus _bus;
        private readonly IWindsorContainer _container;
        private static readonly ILog Log = LogManager.GetLogger<CacheWorker>();
        private Quartz.IScheduler _scheduler;

        public CacheWorker(IWindsorContainer container)
        {
            _container = container;
        }

        public void Start()
        {
            Log.Debug("Starting Cache Worker");
            var properties = new NameValueCollection();
            properties["quartz.scheduler.instanceName"] = "RemoteServer";


            properties["quartz.threadPool.type"] = "Quartz.Simpl.SimpleThreadPool, Quartz";
            properties["quartz.threadPool.threadCount"] = "5";
            properties["quartz.threadPool.threadPriority"] = "Normal";


            properties["quartz.plugin.xml.type"] = "Quartz.Plugin.Xml.XMLSchedulingDataProcessorPlugin, Quartz";
            properties["quartz.plugin.xml.fileNames"] = "jobs.xml";

            ISchedulerFactory schedulerFactory = new StdSchedulerFactory(properties);
            _scheduler = schedulerFactory.GetScheduler();
            _scheduler.JobFactory = new JobFactory(_container);

            _scheduler.Start();

            _bus = _container.Resolve<IAdvancedBus>();
            var receiverQueue = _bus.QueueDeclare("DataPlatform.DataProvider.Cache.Receiver");
            var receiverExchange = _bus.ExchangeDeclare("DataPlatform.DataProvider.Cache.Receiver", ExchangeType.Fanout);
            _bus.Bind(receiverExchange, receiverQueue, string.Empty);

            _bus.Consume(receiverQueue, q => q
                .Add<ClearCacheCommand>(
                (message, info) => new ReceiverConsumers<ClearCacheCommand>(message, _container))
                .Add<RefreshCacheCommand>(
                (message, info) => new ReceiverConsumers<RefreshCacheCommand>(message, _container))
                .Add<RestartCacheDataStoreCommand>(
                (message, info) => new ReceiverConsumers<RestartCacheDataStoreCommand>(message, _container)));

            Log.Debug("Cache Worker has started");
        }

        public void End()
        {
            Log.DebugFormat("Stopping Cache Worker");

            if (_scheduler != null)
            {
                if (!_scheduler.IsShutdown)
                    _scheduler.Shutdown();
            }

            Log.DebugFormat("Stopped Cache Worker");
        }
    }
}
