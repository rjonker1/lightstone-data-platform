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
           // _bus = container.Resolve<IBus>();
            _bus = new BusFactory().CreateBus("monitor-event-tracking/queue", container);

            _log.DebugFormat("Billing monitoring started");

            //var consumers = new ConsumerRegistration()
            //    .AddConsumer<ExternalSourceConsumer, LaceExternalSourceEventMessage>(
            //        () => new ExternalSourceConsumer())
            //    .AddConsumer<ExternalSourceConfigurationConsumer, LaceExternalSourceConfigurationEventMessage>(
            //        () => new ExternalSourceConfigurationConsumer())
            //    .AddConsumer<ExternalSourceFailedConsumer, LaceExternalSourceFailedEventMessage>(
            //        () => new ExternalSourceFailedConsumer())
            //    .AddConsumer<ExternalSourceHandledConsumer, LaceSourceHandledEventMessage>(
            //        () => new ExternalSourceHandledConsumer())
            //    .AddConsumer<ExternalSourceNoResponseReceivedConsumer, LaceExternalSourceNoResponseEventMessage>(
            //        () => new ExternalSourceNoResponseReceivedConsumer())
            //    .AddConsumer<ExternalSourceTransformationConsumer, LaceTransformResponseEventMessage>(
            //        () => new ExternalSourceTransformationConsumer())
            //    .AddConsumer<ExternalSourceReceivedResponseConsumer, LaceExternalSourceResponseEventMessage>(
            //        () => new ExternalSourceReceivedResponseConsumer())
            //    .AddConsumer<ExternalSourceSentRequestsConsumer, LaceExternalSourceRequestEventMessage>(
            //        () => new ExternalSourceSentRequestsConsumer());

           // _bus = new BusFactory().CreateConsumerBus("monitor-event-tracking/queue", consumers);
           // _bus = new BusFactory().CreateBus()
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
