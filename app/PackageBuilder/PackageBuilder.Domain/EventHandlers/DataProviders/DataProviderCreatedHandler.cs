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
            _repository.Save(new DataProvider(command.Id, command.Name, command.Description, command.CostPrice, command.Version, command.Owner, command.CreatedDate, command.EditedDate));
        }
    }
}
