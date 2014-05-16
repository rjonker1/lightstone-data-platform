using EasyNetQ;
using Workflow.BuildingBlocks;
using Workflow.BuildingBlocks.Consumers;


namespace Lace.Events.Consumer.Sources
{
    public class LaceEventService : ILaceEventService
    {
        private IBus _bus;

        public void Start()
        {
            var consumers = new ConsumerRegistration()
                .AddConsumer<SourcesConsumer, ILaceEventMessage>(() => new SourcesConsumer());

            _bus = new BusFactory().CreateConsumerBus("lace/sources/queue", consumers);
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
