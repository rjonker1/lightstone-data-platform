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

        public override void Handle(CreateDataProvider command)
        {
            var entity = new DataProvider(command.Id, command.Name,
                command.Description, command.CostOfSale, command.SourceURL, command.ResponseType, command.State,
                command.Owner, command.CreatedDate, command.EditedDate);

            _repository.Save(entity, Guid.NewGuid());
        }
    }
}