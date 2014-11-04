using System;
using System.Linq;
using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using PackageBuilder.Core.MessageHandling;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Domain.Entities.DataProviders.Commands;
using PackageBuilder.Domain.Entities.DataProviders.WriteModels;
using PackageBuilder.Infrastructure.Repositories;

namespace PackageBuilder.Domain.CommandHandlers.DataProviders
{
    public class UpdateDataProviderHandler : AbstractMessageHandler<UpdateDataProvider>
    {
        private readonly INEventStoreRepository<DataProvider> _writeRepo;
        private readonly IDataProviderRepository _readRepo;

        public UpdateDataProviderHandler(INEventStoreRepository<DataProvider> writeRepo, IDataProviderRepository readRepo)
        {
            _writeRepo = writeRepo;
            _readRepo = readRepo;
        }

        public override void Handle(UpdateDataProvider command)
        {
            //var existing = _readRepo.FirstOrDefault(x => x.Id != command.Id && x.Name.ToLower() == command.Name.ToLower());
            var existing = _readRepo.Exists(command.Id, command.Name);
            if (existing)
                throw new LightstoneAutoException("A data provider with the name {0} already exists".FormatWith(command.Name));

            var latestVersion = _readRepo.Max(x => x.Version);
            if (command.Version != latestVersion)
                throw new LightstoneAutoException("This is an older version, please update the latest version of data provider {0}".FormatWith(command.Name));

            var entity = _writeRepo.GetById(command.Id);
            entity.CreateDataProviderRevision(command.Id, command.Name, command.Description, command.CostOfSale,
                command.SourceURL, command.ResponseType, entity.Version, command.Owner,
                command.CreatedDate,
                command.EditedDate, command.DataFields);

            _writeRepo.Save(entity, Guid.NewGuid());
        }
    }
}