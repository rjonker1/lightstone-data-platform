using System;
using System.Linq;
using AutoMapper;
using DataPlatform.Shared.Messaging.Billing.Messages;
using DataPlatform.Shared.Repositories;
using EasyNetQ;
using Workflow.Billing.Domain.Entities;

namespace Workflow.Billing.Consumers.ConsumerTypes
{
    public class PackageConsumer
    {

        private readonly IRepository<PackageMeta> _packageRepository;

        public PackageConsumer(IRepository<PackageMeta> packageRepository)
        {
            _packageRepository = packageRepository;
        }

        public void Consume(IMessage<PackageMessage> message)
        {

            //New PackageMeta
            var entity = Mapper.Map<PackageMessage, PackageMeta>(message.Body);
            var dbEntity = _packageRepository.Select(x => x).Where(x => x.PackageId == message.Body.PackageId);

            if (dbEntity.Any())
            {

                var updateEntity = new PackageMeta()
                {
                    Id = dbEntity.FirstOrDefault().Id,
                    Created = dbEntity.FirstOrDefault().Created,
                    CreatedBy = dbEntity.FirstOrDefault().CreatedBy,
                    PackageId = dbEntity.FirstOrDefault().PackageId,
                    PackageName = entity.PackageName,
                    Modified = DateTime.UtcNow,
                    ModifiedBy = GetType().Assembly.FullName
                };

                _packageRepository.SaveOrUpdate(updateEntity);
                return;
            }

            _packageRepository.SaveOrUpdate(entity);
        }
    }
}