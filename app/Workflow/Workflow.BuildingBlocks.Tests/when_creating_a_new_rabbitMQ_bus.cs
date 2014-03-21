using EasyNetQ;
using Workflow.BuildingBlocks.Consumers;
using Workflow.BuildingBlocks.Tests.Fakes;
using Workflow.BuildingBlocks.Tests.Mothers;
using Xunit.Extensions;

namespace Workflow.BuildingBlocks.Tests
{
    public class when_creating_a_new_rabbitMQ_bus : Specification
    {
        private readonly BusFactory factory;
        private readonly ConsumerRegistration consumers;
        private IBus bus;

        public when_creating_a_new_rabbitMQ_bus()
        {
            factory = new BusFactory();
            consumers = new ConsumerRegistration()
                .AddConsumer<TestMessageConsumer, TestMessage>(() => new TestMessageConsumer());
        }

        public override void Observe()
        {
            using (bus = factory.Create("test_rabbitmq_creation", consumers))
            {
            }
        }

        [Observation]
        public void then_the_bus_is_created()
        {
            bus.ShouldNotBeNull();
        }
    }
}
