using System;
using DataPlatform.Shared.Public.Messaging;
using DataPlatform.Workflow.RabbitMQ.Tests.Fakes;
using Xunit.Extensions;

namespace DataPlatform.Workflow.RabbitMQ.Tests.Publisher
{
    public class when_publishing_a_null_message_to_rabbitmq : Specification
    {
        private readonly FakeBus bus;
        private readonly IPublishableMessage message;
        private readonly IPublishMessages publisher;
        private Exception thrownException;

        public when_publishing_a_null_message_to_rabbitmq()
        {
            bus = new FakeBus();
            message = null;
            publisher = new RabbitMQ.Publisher(bus);
        }

        public override void Observe()
        {
            try
            {
                publisher.Publish(message);
            }
            catch (Exception e)
            {
                thrownException = e;
            }
        }

        [Observation]
        public void the_underlying_bus_is_not_invoked()
        {
            bus.PublishWasCalled.ShouldBeFalse();
        }

        [Observation]
        public void an_exception_is_thrown()
        {
            thrownException.ShouldNotBeNull();
        }

        [Observation]
        public void an_argument_null_exception_is_thrown()
        {
            thrownException.ShouldBeType<ArgumentNullException>();
        }


    }
}