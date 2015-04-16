﻿using AutoMapper;
using DataPlatform.Shared.Repositories;
using EasyNetQ.AutoSubscribe;
using Shared.Messaging.Billing.Messages;
using Workflow.Billing.Domain.Entities;

namespace Workflow.Billing.Consumers
{
    public class EntityConsumer : IConsume<UserMessage>
    {
        private readonly IRepository<UserMeta> _repository;

        private readonly IRepository<PreBilling> _preBillings; 

        public EntityConsumer(IRepository<UserMeta> repository)
        {
            _repository = repository;
        }

        public void Consume(UserMessage message)
        {
            //New User
            var entity = Mapper.Map<UserMessage, UserMeta>(message);
            _repository.SaveOrUpdate(entity);
        }

    }

    
}