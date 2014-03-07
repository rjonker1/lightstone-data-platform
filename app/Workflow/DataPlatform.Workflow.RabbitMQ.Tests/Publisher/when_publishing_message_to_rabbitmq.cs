using DataPlatform.Shared.Public.Messaging;
using DataPlatform.Workflow.RabbitMQ.Tests.Fakes;
using DataPlatform.Workflow.RabbitMQ.Tests.Mothers.Publisher;
using Xunit.Extensions;

namespace DataPlatform.Workflow.RabbitMQ.Tests.Publisher
{
    public class when_publishing_message_to_rabbitmq : Specification
    {
        private readonly FakeBus bus;
        private readonly IPublishableMessage message;
        private readonly IPublishMessages publisher;

        public when_publishing_message_to_rabbitmq()
        {
            bus = new FakeBus();
            message = new TestMessage();
            publisher = new RabbitMQ.Publisher(bus);
        }

        public override void Observe()
        {
            publisher.Publish(message);
        }

        [Observation]
        public void the_underlying_bus_is_invoked()
        {
            bus.PublishedWasCalled.ShouldBeTrue();
        }

        [Observation]
        public void the_message_is_published_using_the_bus()
        {
            bus.PublishedMessage.ShouldNotBeNull();
            bus.PublishedMessage.ShouldBeType<TestMessage>();
        }
    }
}