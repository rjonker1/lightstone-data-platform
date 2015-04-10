using System;
<<<<<<< Updated upstream
using Castle.MicroKernel.Registration;
using Castle.Windsor;
=======
using AutoMapper;
using Billing.Api.Helpers.AutoMapper.Maps;
using Billing.Api.Installers;
using Billing.TestHelper;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using DataPlatform.Shared.Repositories;
>>>>>>> Stashed changes
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
                Mapper.CreateMap<UserMessage, UserMeta>();
                consumer.Consume(message);
            }
            catch (Exception e)
            {
                thrownException = e;
            }
        }

        [Observation]
        public void should_consume_message()
        {
            thrownException.ShouldBeNull();
        }
    }
}