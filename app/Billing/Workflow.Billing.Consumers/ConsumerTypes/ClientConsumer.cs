using System;
using System.Linq;
using AutoMapper;
using DataPlatform.Shared.Messaging.Billing.Messages;
using DataPlatform.Shared.Repositories;
using EasyNetQ;
using Workflow.Billing.Domain.Entities;

namespace Workflow.Billing.Consumers.ConsumerTypes
{
    public class ClientConsumer
    {
        private readonly IRepository<Client> _accountRepository;

        public ClientConsumer(IRepository<Client> accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public void Consume(IMessage<ClientMessage> message)
        {
            // New Client
            var entity = Mapper.Map<ClientMessage, Client>(message.Body);
            var dbEntity = _accountRepository.Select(x => x).Where(x => x.ClientId == message.Body.ClientId);

            if (dbEntity.Any())
            {

                var updateEntity = new Client()
                {
                    Id = dbEntity.FirstOrDefault().Id,
                    AccountNumber = dbEntity.FirstOrDefault().AccountNumber,
                    AccountOwner = entity.AccountOwner,
                    BillingType = entity.BillingType,
                    PaymentType = entity.PaymentType,
                    Created = dbEntity.FirstOrDefault().Created,
                    CreatedBy = dbEntity.FirstOrDefault().CreatedBy,
                    ClientId = dbEntity.FirstOrDefault().ClientId,
                    ClientName = entity.ClientName,
                    Modified = DateTime.UtcNow,
                    ModifiedBy = GetType().Assembly.FullName
                };

                _accountRepository.SaveOrUpdate(updateEntity);
                return;
            }

            _accountRepository.SaveOrUpdate(entity);
        }
    }
}