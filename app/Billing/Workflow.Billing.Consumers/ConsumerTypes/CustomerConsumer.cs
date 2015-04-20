using AutoMapper;
using DataPlatform.Shared.Messaging.Billing.Messages;
using DataPlatform.Shared.Repositories;
using EasyNetQ;
using Workflow.Billing.Domain.Entities;

namespace Workflow.Billing.Consumers.ConsumerTypes
{
    public class CustomerConsumer
    {
        private readonly IRepository<AccountMeta> _accountResRepository;

        public CustomerConsumer(IRepository<AccountMeta> accountResRepository)
        {
            _accountResRepository = accountResRepository;
        }

        public void Consume(IMessage<CustomerMessage> message)
        {
            //New Customer
            var entity = Mapper.Map<CustomerMessage, Customer>(message.Body);
            _accountResRepository.SaveOrUpdate(entity);
        }
    }
}