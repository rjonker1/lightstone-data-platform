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
            var dbEntity = _contracts.Select(x => x).Where(x => x.ContractId == message.Body.ContractId);

            if (dbEntity.Any())
            {

                var updateEntity = new ContractMeta()
                {
                    Id = dbEntity.FirstOrDefault().Id,
                    Created = dbEntity.FirstOrDefault().Created,
                    CreatedBy = dbEntity.FirstOrDefault().CreatedBy,
                    Modified = DateTime.UtcNow,
                    ModifiedBy = GetType().Assembly.FullName,
                    ContractId = entity.ContractId,
                    ContractName = entity.ContractName,
                    ContractBundleId = entity.ContractBundleId,
                    ContractBundleName = entity.ContractName,
                    ContractBundleTransactionLimit = entity.ContractBundleTransactionLimit,
                    ContractBundlePrice = entity.ContractBundlePrice
                };

                _contracts.SaveOrUpdate(updateEntity);
                return;
            }

            _contracts.SaveOrUpdate(entity);
        }
    }
}