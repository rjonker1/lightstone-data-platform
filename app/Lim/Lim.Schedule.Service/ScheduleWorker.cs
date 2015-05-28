using System.Collections.Specialized;
using Castle.Windsor;
using Common.Logging;
using EasyNetQ;
using EasyNetQ.Topology;
using Lim.Domain.Messaging.Messages;
using Lim.Schedule.Service.Consumers;
using Lim.Schedule.Service.Jobs;
using Quartz;
using Quartz.Impl;
using IScheduler = Quartz.IScheduler;

namespace Lim.Schedule.Service
{
    public interface IScheduleLimIntegration
    {
        void Start();
        void End();
    }

    public class ScheduleWorker : IScheduleLimIntegration
    {
        private readonly IWindsorContainer _container;
        private static readonly ILog Log = LogManager.GetLogger<ScheduleWorker>();
        private IScheduler _scheduler;

        public ScheduleWorker(IWindsorContainer container)
        {
            _container = container;
        }

        public void Start()
        {
            Log.Debug("Starting LIM Scheduler");
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

            var bus = _container.Resolve<IAdvancedBus>();

            var senderQueue = bus.QueueDeclare("DataPlatform.Integration.Sender");
            var senderExchange = bus.ExchangeDeclare("DataPlatform.Integration.Sender", ExchangeType.Fanout);
            bus.Bind(senderExchange, senderQueue, string.Empty);

            var receiverQueue = bus.QueueDeclare("DataPlatform.Integration.Receiver");
            var receiverExchange = bus.ExchangeDeclare("DataPlatform.Integration.Receiver", ExchangeType.Fanout);
            bus.Bind(receiverExchange, receiverQueue, string.Empty);

            bus.Consume(senderQueue,
                q =>
                    q.Add<PackageResponseMessage>(
                        (message, info) => new SenderConsumers<PackageResponseMessage>(message, _container)));

            bus.Consume(receiverQueue,
                q =>
                    q.Add<PackageConfigurationMessage>(
                        (message, info) => new ReceiverConsumers<PackageConfigurationMessage>(message, _container)));

            _scheduler.Start();

            Log.Debug("LIM Scheduler has started");
        }

        public void End()
        {
            Log.DebugFormat("Stopping LIM Scheduler");

            if (_scheduler != null)
            {
                if (!_scheduler.IsShutdown)
                    _scheduler.Shutdown();
            }

            Log.DebugFormat("Stopped LIM Scheduler");
        }
    }
}
