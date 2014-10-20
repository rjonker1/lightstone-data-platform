using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Entities.DataProviders.Events;
using PackageBuilder.Domain.Entities.DataProviders.ReadModels;
using PackageBuilder.Domain.MessageHandling;

namespace PackageBuilder.Domain.EventHandlers.DataProviders
{
    public class DataProviderCreatedHandler : AbstractMessageHandler<DataProviderCreated>
    {
        private readonly IRepository<DataProvider> _repository;

        public DataProviderCreatedHandler(IRepository<DataProvider> repository)
        {
            _repository = repository;
        }

        public override void Handle(DataProviderCreated command)
        {
            var dataProvider = new DataProvider(command.Id, command.DataProviderId, command.Name, command.CostOfSale, command.Description, command.Owner);
            _repository.Save(dataProvider);
        }
    }
}
