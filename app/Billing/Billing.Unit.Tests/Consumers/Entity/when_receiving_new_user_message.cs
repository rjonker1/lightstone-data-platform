using System;
using AutoMapper;
using DataPlatform.Shared.Messaging.Billing.Messages;
using DataPlatform.Shared.Repositories;
using EasyNetQ;
using Moq;
using Workflow.Billing.Consumers.ConsumerTypes;
using Workflow.Billing.Domain.Entities;
using Xunit.Extensions;

namespace Billing.Api.Tests.Consumers.Entity
{
    public class when_receiving_new_user_message : Specification
    {
        private readonly UserConsumer consumer;
        private readonly IMessage<UserMessage> message;
        private readonly Mock<IRepository<UserMeta>> repository;
        private readonly Mock<IRepository<Transaction>> transactions;
        private readonly Mock<IRepository<PreBilling>> preBillings;

        private Exception thrownException;

        public when_receiving_new_user_message()
        {
            repository = new Mock<IRepository<UserMeta>>();

            //Requires tables to be populated
            //consumer = new EntityConsumer(repository.Object, transactions.Object, preBillings.Object);
            //message = new UserMessage();
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
            thrownException.ShouldNotBeNull();
        }
    }
}