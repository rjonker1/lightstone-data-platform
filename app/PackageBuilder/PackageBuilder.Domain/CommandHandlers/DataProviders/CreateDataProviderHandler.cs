using System;
using System.Collections.Generic;
using AutoMapper;
using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using PackageBuilder.Core.MessageHandling;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.DataProviders.Commands;
using PackageBuilder.Domain.Entities.DataProviders.Write;
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
            {
                var exception = new LightstoneAutoException("A data provider with the name: {0} already exists".FormatWith(command.Name));
                this.Warn(() => exception);
                //throw exception;
                return;
            }

            var dataFields = Mapper.Map(command.DataProvider, command.DataProvider.GetType(), typeof(IEnumerable<IDataField>)) as IEnumerable<IDataField>;

            var entity = new DataProvider(command.Id, command.Name,
                command.Description, command.CostOfSale, command.ResponseType,
                command.Owner, command.CreatedDate, dataFields);

            _writeRepo.Save(entity, Guid.NewGuid());
        }
    }
}