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
    public class UpdateDataProviderHandler : AbstractMessageHandler<UpdateDataProvider>
    {
        private readonly INEventStoreRepository<DataProvider> _writeRepo;
        private readonly IRepository<Entities.DataProviders.ReadModels.DataProvider> _readRepo;


        public UpdateDataProviderHandler(INEventStoreRepository<DataProvider> writeRepo, IRepository<Entities.DataProviders.ReadModels.DataProvider> readRepo)
        {
            _writeRepo = writeRepo;
            _readRepo = readRepo;
        }

        public override void Handle(UpdateDataProvider command)
        {
            var existing = _readRepo.FirstOrDefault(x => x.Id != command.Id && x.Name.ToLower() == command.Name.ToLower());
            if (existing != null)
                throw new LightstoneAutoException("A data provider with the name {0} already exists".FormatWith(command.Name));

            var entity = _writeRepo.GetById(command.Id);
            entity.CreateDataProviderRevision(command.Id, command.Name, command.Description, command.CostOfSale,
                command.SourceURL, command.ResponseType, entity.Version, command.Owner,
                command.CreatedDate,
                command.EditedDate, command.DataFields);

            _writeRepo.Save(entity, Guid.NewGuid());
        }
    }
}