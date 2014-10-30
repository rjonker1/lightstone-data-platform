using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Entities.DataProviders.Events;
using PackageBuilder.Domain.Entities.DataProviders.ReadModels;
using PackageBuilder.Domain.MessageHandling;

namespace PackageBuilder.Domain.EventHandlers.DataProviders
{
    public class DataProviderUpdatedHandler : AbstractMessageHandler<DataProviderUpdated>
    {
        private readonly IRepository<DataProvider> _repository;

        public DataProviderUpdatedHandler(IRepository<DataProvider> repository)
        {
            _repository = repository;
        }

        public override void Handle(DataProviderUpdated command)
        {
            _repository.Save(new DataProvider(command.Id, command.Name, command.Description, command.CostPrice, command.Version+=1, command.Owner, command.CreatedDate, command.EditedDate));
        }
    }
}
