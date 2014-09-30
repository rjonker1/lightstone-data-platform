using System;
using PackageBuilder.Domain.DataProviders.WriteModels;
using PackageBuilder.Domain.Helpers.Cqrs.NEventStore;
using PackageBuilder.Domain.Helpers.MessageHandling;

namespace PackageBuilder.Domain.DataProviders.Commands.Handlers
{
    public class CreateDataProviderHandler : AbstractMessageHandler<CreateDataProvider>
    {
        private readonly IRepository<DataProvider> _repository;

        public CreateDataProviderHandler(IRepository<DataProvider> repository)
        {
            _repository = repository;
        }

        public override void Handle(CreateDataProvider domainCommand)
        {
            var entity = new DataProvider(domainCommand.Id, domainCommand.Version, domainCommand.Name, domainCommand.DataProviderType);

            _repository.Save(entity, Guid.NewGuid());
        }
    }
}