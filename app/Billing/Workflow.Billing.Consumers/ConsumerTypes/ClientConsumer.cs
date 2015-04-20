using AutoMapper;
using DataPlatform.Shared.Messaging.Billing.Messages;
using DataPlatform.Shared.Repositories;
using EasyNetQ;
using Workflow.Billing.Domain.Entities;

namespace Workflow.Billing.Consumers.ConsumerTypes
{
    public class ClientConsumer
    {
        private readonly IRepository<AccountMeta> _accountRepository;

        public ClientConsumer(IRepository<AccountMeta> accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public void Consume(IMessage<ClientMessage> message)
        {
            //New Client
            var entity = Mapper.Map<ClientMessage, Client>(message.Body);
            _accountRepository.SaveOrUpdate(entity);
        }
    }
}