using System;
using System.Linq;
using AutoMapper;
using DataPlatform.Shared.Messaging.Billing.Messages;
using DataPlatform.Shared.Repositories;
using EasyNetQ;
using Workflow.Billing.Domain.Entities;

namespace Workflow.Billing.Consumers.ConsumerTypes
{
    public class ContractConsumer
    {
        private readonly IRepository<ContractMeta> _contracts;

        public ContractConsumer(IRepository<ContractMeta> contracts)
        {
            _contracts = contracts;
        }

        public void Consume(IMessage<ContractMessage> message)
        {
            // New ContractMeta
            var entity = Mapper.Map<ContractMessage, ContractMeta>(message.Body);
            var dbEntity = _contracts.Select(x => x).Where(x => x.Id == message.Body.Id);

            if (dbEntity.Any())
            {

                var updateEntity = new ContractMeta()
                {
                    Id = dbEntity.FirstOrDefault().Id,
                    Created = dbEntity.FirstOrDefault().Created,
                    CreatedBy = dbEntity.FirstOrDefault().CreatedBy,
                    Modified = DateTime.UtcNow,
                    ModifiedBy = GetType().Assembly.FullName,
                    ContractName = dbEntity.FirstOrDefault().ContractName,
                    ContractBundleId = dbEntity.FirstOrDefault().ContractBundleId,
                    ContractBundleName = dbEntity.FirstOrDefault().ContractName,
                    ContractBundleTransactionLimit = dbEntity.FirstOrDefault().ContractBundleTransactionLimit,
                    ContractBundlePrice = dbEntity.FirstOrDefault().ContractBundlePrice
                };

                _contracts.SaveOrUpdate(updateEntity);
                return;
            }

            _contracts.SaveOrUpdate(entity);
        }
    }
}