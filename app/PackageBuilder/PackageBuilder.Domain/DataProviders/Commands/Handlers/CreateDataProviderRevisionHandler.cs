﻿using System;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Domain.DataProviders.WriteModels;
using PackageBuilder.Domain.MessageHandling;

namespace PackageBuilder.Domain.DataProviders.Commands.Handlers
{
    public class CreateDataProviderRevisionHandler : AbstractMessageHandler<CreateDataProviderRevision>
    {
        private readonly INEventStoreRepository<DataProvider> _repository;

        public CreateDataProviderRevisionHandler(INEventStoreRepository<DataProvider> repository)
        {
            _repository = repository;
        }

        public override void Handle(CreateDataProviderRevision command)
        {

            var entity = _repository.GetById(command.Id);
            entity.CreateDataProviderRevision(command.Id, command.Version, command.Name, command.DataProviderType, command.DataFields);
            _repository.Save(entity, Guid.NewGuid());

        }
    }
}