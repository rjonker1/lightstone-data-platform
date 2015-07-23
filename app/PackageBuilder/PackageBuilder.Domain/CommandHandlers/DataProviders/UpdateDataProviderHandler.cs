using System;
using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using PackageBuilder.Core.MessageHandling;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Domain.Entities.DataProviders.Commands;
using PackageBuilder.Domain.Entities.DataProviders.Write;
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
            var existing = _readRepo.Exists(command.Id, command.Name);
            if (existing)
            {
                var exception = new LightstoneAutoException("A data provider with the name {0} already exists".FormatWith(command.Name));
                this.Warn(() => exception);
                throw exception;
            }

            var entity = _writeRepo.GetById(command.Id);
            entity.CreateDataProviderRevision(command.Id, command.Name, command.Description, command.CostOfSale,
               command.ResponseType, command.FieldLevelCostPriceOverride, entity.Version,
               command.Owner, command.CreatedDate, command.EditedDate, command.RequestFields, command.DataFields);

            _writeRepo.Save(entity, Guid.NewGuid(), true);
        }
    }
}