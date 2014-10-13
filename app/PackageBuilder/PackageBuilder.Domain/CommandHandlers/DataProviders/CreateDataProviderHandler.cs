using System;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Domain.Entities.DataProviders.Commands;
using PackageBuilder.Domain.Entities.DataProviders.WriteModels;
using PackageBuilder.Domain.MessageHandling;

namespace PackageBuilder.Domain.CommandHandlers.DataProviders
{
    public class CreateDataProviderHandler : AbstractMessageHandler<CreateDataProvider>
    {
        private readonly INEventStoreRepository<DataProvider> _repository;

        public CreateDataProviderHandler(INEventStoreRepository<DataProvider> repository)
        {
            _repository = repository;
        }

        public override void Handle(CreateDataProvider domainCommand)
        {
            var entity = new DataProvider(domainCommand.Id, domainCommand.Name, domainCommand.Description, domainCommand.DataProviderType);

            _repository.Save(entity, Guid.NewGuid());
        }
    }
}