using System;
using System.Linq;
using AutoMapper;
using DataPlatform.Shared.Messaging.Billing.Messages;
using DataPlatform.Shared.Repositories;
using EasyNetQ;
using Workflow.Billing.Domain.Entities;

namespace Workflow.Billing.Consumers.ConsumerTypes
{
    public class CustomerConsumer
    {
        private readonly IRepository<Customer> _accountRepository;

        public CustomerConsumer(IRepository<Customer> accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public void Consume(IMessage<CustomerMessage> message)
        {
            // New Customer
            var entity = Mapper.Map<CustomerMessage, Customer>(message.Body);
            var dbEntity = _accountRepository.Select(x => x).Where(x => x.CustomerId == message.Body.CustomerId);

            if (dbEntity.Any())
            {

                var updateEntity = new Customer()
                {
                    Id = dbEntity.FirstOrDefault().Id,
                    AccountNumber = dbEntity.FirstOrDefault().AccountNumber,
                    AccountOwner = entity.AccountOwner,
                    BillingType = entity.BillingType,
                    PaymentType = entity.PaymentType,
                    Created = dbEntity.FirstOrDefault().Created,
                    CreatedBy = dbEntity.FirstOrDefault().CreatedBy,
                    CustomerId = dbEntity.FirstOrDefault().CustomerId,
                    CustomerName = entity.CustomerName,
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