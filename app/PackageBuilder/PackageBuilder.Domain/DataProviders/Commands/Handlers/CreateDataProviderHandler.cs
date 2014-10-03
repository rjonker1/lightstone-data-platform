using System;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Domain.DataProviders.WriteModels;
using PackageBuilder.Domain.MessageHandling;

namespace PackageBuilder.Domain.DataProviders.Commands.Handlers
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
            var entity = new DataProvider(domainCommand.Id, domainCommand.Name, domainCommand.DataProviderType);

            _repository.Save(entity, Guid.NewGuid());
        }
    }
}