using Castle.Windsor;
using Castle.Windsor.Installer;
using Common.Logging;
using EasyNetQ;
using Workflow.BuildingBlocks;

namespace Monitoring.Consumer
{
    public class MonitorService : IMonitoringService
    {
        private readonly ILog _log = LogManager.GetCurrentClassLogger();
        private IBus _bus;

        public void Start()
        {
            _log.DebugFormat("Started monitoring service");

            var container = new WindsorContainer().Install(FromAssembly.This());
            _bus = new BusFactory().CreateBus("monitor-event-tracking/queue", container);

            _log.DebugFormat("Billing monitoring started");
        }

        public void Stop()
        {
            if (_bus != null)
            {
                _bus.Dispose();
            }

        }
    }
}
