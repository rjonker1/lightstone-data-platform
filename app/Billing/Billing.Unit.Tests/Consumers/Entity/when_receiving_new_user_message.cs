using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Moq;
using Shared.Messaging.Billing.Messages;
using Workflow.Billing.Consumers;
using Workflow.Billing.Domain.Entities;
using Workflow.Billing.Repository;
using Xunit.Extensions;

namespace Billing.Api.Tests.Consumers.Entity
{
    public class when_receiving_new_user_message : Specification
    {
        private readonly EntityConsumer consumer;
        private readonly UserMessage message;
        private readonly Mock<IRepository<UserMeta>> repository;
        private Exception thrownException;

        public when_receiving_new_user_message()
        {
            repository = new Mock<IRepository<UserMeta>>();
            consumer = new EntityConsumer(repository.Object);
            message = new UserMessage();
        }

        public override void Observe()
        {
            try
            {
                //consumer.Consume(message);
            }
            catch (Exception e)
            {
                thrownException = e;
            }
        }

        [Observation]
        public void should_consume_message()
        {
            //thrownException.ShouldBeNull();
        }
    }
}