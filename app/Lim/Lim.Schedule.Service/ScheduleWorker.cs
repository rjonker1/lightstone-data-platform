using System.Collections.Specialized;
using Castle.Windsor;
using Common.Logging;
using Lim.Schedule.Service.Jobs;
using Quartz;
using Quartz.Impl;

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
