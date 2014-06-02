using EasyNetQ;
using Monitoring.Modules.Lace.Consumers;
using Monitoring.Modules.Lace.Messages;
using Workflow.BuildingBlocks;
using Workflow.BuildingBlocks.Consumers;

namespace Monitoring.Consumer
{
    public class MonitorService : IMonitoringService
    {
        private IBus _bus;

        public void Start()
        {
            var consumers = new ConsumerRegistration()
                .AddConsumer<ExternalSourceConsumer, LaceExternalServiceEventMessage>(
                    () => new ExternalSourceConsumer())
                .AddConsumer<ExternalSourceConfigurationConsumer, LaceExternalServiceConfigurationEventMessage>(
                    () => new ExternalSourceConfigurationConsumer())
                .AddConsumer<ExternalSourceFailedConsumer, LaceExternalServiceFailedEventMessage>(
                    () => new ExternalSourceFailedConsumer())
                .AddConsumer<ExternalSourceHandledConsumer, LaceSourceHandledEventMessage>(
                    () => new ExternalSourceHandledConsumer())
                .AddConsumer<ExternalSourceNoResponseReceivedConsumer, LaceExternalServiceNoResponseEventMessage>(
                    () => new ExternalSourceNoResponseReceivedConsumer())
                .AddConsumer<ExternalSourceTransformationConsumer, LaceTransformResponseEventMessage>(
                    () => new ExternalSourceTransformationConsumer())
                .AddConsumer<ExternalSourceReceivedResponseConsumer, LaceExternalServiceResponseEventMessage>(
                    () => new ExternalSourceReceivedResponseConsumer())
                .AddConsumer<ExternalSourceSentRequestsConsumer, LaceExternalServiceRequestEventMessage>(
                    () => new ExternalSourceSentRequestsConsumer());

            _bus = new BusFactory().CreateConsumerBus("monitor-event-tracking/queue", consumers);
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
