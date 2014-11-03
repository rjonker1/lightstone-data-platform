using System;
using System.Linq;
using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Entities.DataProviders.Commands;
using PackageBuilder.Domain.Entities.DataProviders.WriteModels;
using PackageBuilder.Domain.MessageHandling;

namespace PackageBuilder.Domain.CommandHandlers.DataProviders
{
    public class CreateDataProviderHandler : AbstractMessageHandler<CreateDataProvider>
    {
        private readonly INEventStoreRepository<DataProvider> _writeRepo;
        private readonly IRepository<Entities.DataProviders.ReadModels.DataProvider> _readRepo;

        public CreateDataProviderHandler(INEventStoreRepository<DataProvider> writeRepo, IRepository<Entities.DataProviders.ReadModels.DataProvider> readRepo)
        {
            _writeRepo = writeRepo;
            _readRepo = readRepo;
        }

        public override void Handle(CreateDataProvider command)
        {
            var existing = _readRepo.FirstOrDefault(x => x.Name.ToLower() == command.Name.ToLower());
            if (existing != null)
                throw new LightstoneAutoException("A data provider with the name {0} already exists".FormatWith(command.Name));

            var entity = new DataProvider(command.Id, command.Name,
                command.Description, command.CostOfSale, command.SourceURL, command.ResponseType, command.State,
                command.Owner, command.CreatedDate, command.EditedDate);

            _writeRepo.Save(entity, Guid.NewGuid());
        }
    }
}