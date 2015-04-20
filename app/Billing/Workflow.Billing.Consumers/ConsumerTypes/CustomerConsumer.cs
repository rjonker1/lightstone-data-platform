﻿using AutoMapper;
using DataPlatform.Shared.Messaging.Billing.Messages;
using DataPlatform.Shared.Repositories;
using EasyNetQ;
using Workflow.Billing.Domain.Entities;

namespace Workflow.Billing.Consumers.ConsumerTypes
{
    public class CustomerConsumer
    {
        private readonly IRepository<AccountMeta> _accountRepository;

        public CustomerConsumer(IRepository<AccountMeta> accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public void Consume(IMessage<CustomerMessage> message)
        {
            //New Customer
            var entity = Mapper.Map<CustomerMessage, Customer>(message.Body);
            _accountRepository.SaveOrUpdate(entity);
        }
    }
}