using EasyNetQ;
using Xunit.Extensions;

namespace Workflow.BuildingBlocks.Tests
{
    public class when_creating_a_new_rabbitMQ_bus : Specification
    {
        private IBus _bus;

        public when_creating_a_new_rabbitMQ_bus()
        {

        }

        public override void Observe()
        {
            using (_bus = BusFactory.CreateBus("test_rabbitmq_creation"))
            {
                
            }
        }

        [Observation]
        public void then_the_bus_is_created()
        {
            _bus.ShouldNotBeNull();
        }
    }
}
