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
                .AddConsumer<ExternalSourceConsumer, LaceExternalSourceEventMessage>(
                    () => new ExternalSourceConsumer())
                .AddConsumer<ExternalSourceConfigurationConsumer, LaceExternalSourceConfigurationEventMessage>(
                    () => new ExternalSourceConfigurationConsumer())
                .AddConsumer<ExternalSourceFailedConsumer, LaceExternalSourceFailedEventMessage>(
                    () => new ExternalSourceFailedConsumer())
                .AddConsumer<ExternalSourceHandledConsumer, LaceSourceHandledEventMessage>(
                    () => new ExternalSourceHandledConsumer())
                .AddConsumer<ExternalSourceNoResponseReceivedConsumer, LaceExternalSourceNoResponseEventMessage>(
                    () => new ExternalSourceNoResponseReceivedConsumer())
                .AddConsumer<ExternalSourceTransformationConsumer, LaceTransformResponseEventMessage>(
                    () => new ExternalSourceTransformationConsumer())
                .AddConsumer<ExternalSourceReceivedResponseConsumer, LaceExternalSourceResponseEventMessage>(
                    () => new ExternalSourceReceivedResponseConsumer())
                .AddConsumer<ExternalSourceSentRequestsConsumer, LaceExternalSourceRequestEventMessage>(
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
