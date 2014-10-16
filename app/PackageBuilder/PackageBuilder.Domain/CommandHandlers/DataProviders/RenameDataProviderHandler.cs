using System;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Domain.Entities.DataProviders.Commands;
using PackageBuilder.Domain.Entities.DataProviders.WriteModels;
using PackageBuilder.Domain.MessageHandling;

namespace PackageBuilder.Domain.CommandHandlers.DataProviders
{
    public class RenameDataProviderHandler : AbstractMessageHandler<RenameDataProvider>
    {
        private readonly INEventStoreRepository<DataProvider> _repository;

        public RenameDataProviderHandler(INEventStoreRepository<DataProvider> repository)
        {
            _repository = repository;
        }

        public override void Handle(RenameDataProvider command)
        {
            var entity = _repository.GetById(command.Id);
            entity.ChangeName(command.NewName);
            _repository.Save(entity, Guid.NewGuid());
        }
    }
}