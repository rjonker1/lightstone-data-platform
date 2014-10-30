﻿using System;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Domain.Entities.DataProviders.Commands;
using PackageBuilder.Domain.Entities.DataProviders.WriteModels;
using PackageBuilder.Domain.MessageHandling;

namespace PackageBuilder.Domain.CommandHandlers.DataProviders
{
    public class UpdateDataProviderHandler : AbstractMessageHandler<UpdateDataProvider>
    {
        private readonly INEventStoreRepository<DataProvider> _repository;

        public UpdateDataProviderHandler(INEventStoreRepository<DataProvider> repository)
        {
            _repository = repository;
        }

        public override void Handle(UpdateDataProvider command)
        {
            var entity = _repository.GetById(command.Id);
            entity.CreateDataProviderRevision(command.Id, command.Name, command.Description, command.CostOfSale,
                command.SourceURL, command.ResponseType, command.State, entity.Version, command.Owner,
                command.CreatedDate,
                command.EditedDate, command.DataFields);

            _repository.Save(entity, Guid.NewGuid());
        }
    }
}