﻿using System;
using DataPlatform.Shared.Messaging;
using Workflow.RabbitMQ.Tests.Fakes;
using Workflow.RabbitMQ.Tests.Mothers.Publisher;
using Xunit.Extensions;

namespace Workflow.RabbitMQ.Tests.Publisher
{
    public class when_publishing_a_message_and_the_underlying_bus_fails : Specification
    {
        private readonly FailingBus bus;
        private readonly IPublishableMessage message;
        private readonly IPublishMessages publisher;
        private Exception thrownException;

        public when_publishing_a_message_and_the_underlying_bus_fails()
        {
            bus = new FailingBus();
            message = new TestMessage();
            publisher = new global::Workflow.RabbitMQ.Publisher(bus, new TestingRetryStrategy());
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
        public void the_bus_retried()
        {
            bus.NumberOfTimesCalled.ShouldEqual(2);
        }

        [Observation]
        public void an_exception_is_thrown()
        {
            thrownException.ShouldNotBeNull();
        }
    }
}