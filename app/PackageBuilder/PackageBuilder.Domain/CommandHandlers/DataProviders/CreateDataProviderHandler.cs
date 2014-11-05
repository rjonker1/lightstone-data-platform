using System;
using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using PackageBuilder.Core.MessageHandling;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Domain.Entities.DataProviders.Commands;
using PackageBuilder.Domain.Entities.DataProviders.WriteModels;
using PackageBuilder.Infrastructure.Repositories;

namespace PackageBuilder.Domain.CommandHandlers.DataProviders
{
    public class CreateDataProviderHandler : AbstractMessageHandler<CreateDataProvider>
    {
        private readonly INEventStoreRepository<DataProvider> _writeRepo;
        private readonly IDataProviderRepository _readRepo;

        public CreateDataProviderHandler(INEventStoreRepository<DataProvider> writeRepo, IDataProviderRepository readRepo)
        {
            _writeRepo = writeRepo;
            _readRepo = readRepo;
        }

        public override void Handle(CreateDataProvider command)
        {
            var existing = _readRepo.Exists(command.Id, command.Name);
            if (existing)
                throw new LightstoneAutoException("A data provider with the name {0} already exists".FormatWith(command.Name));

            var entity = new DataProvider(command.Id, command.Name,
                command.Description, command.CostOfSale, command.SourceURL, command.ResponseType,
                command.Owner, command.CreatedDate, command.EditedDate);

            _writeRepo.Save(entity, Guid.NewGuid());
        }
    }
}