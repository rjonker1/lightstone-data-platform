using EasyNetQ;
using EventTracking.Consumers;
using Workflow.BuildingBlocks;
using Workflow.BuildingBlocks.Consumers;

namespace EventTracking.Consumer
{
    public class EventTrackingService : IEventTrackingService
    {
        private IBus _bus;

        public void Start()
        {
            var consumers = new ConsumerRegistration()
                .AddConsumer<ExternalSourceConsumer, ITrackExternalSourceEventMessage>(() => new ExternalSourceConsumer());

            _bus = new BusFactory().CreateConsumerBus("event-tracking/queue", consumers);
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
