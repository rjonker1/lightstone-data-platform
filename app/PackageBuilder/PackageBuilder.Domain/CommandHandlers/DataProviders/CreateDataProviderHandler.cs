using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataPlatform.Shared.Entities;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using Lace.Domain.Core.Contracts.DataProviders;
using PackageBuilder.Core.MessageHandling;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Entities.DataProviders.Commands;
using PackageBuilder.Domain.Entities.DataProviders.WriteModels;
using PackageBuilder.Domain.Entities.Enums;
using PackageBuilder.Domain.Entities.States.WriteModels;
using PackageBuilder.Infrastructure.Repositories;
using PackageBuilder.TestHelper.Builders.Mothers.DataProviderResponses;

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
                command.Owner, command.CreatedDate, command.EditedDate, command.DataFields);

            _writeRepo.Save(entity, Guid.NewGuid());
        }
    }

    public class CreateLightstoneDataProviderHandler : AbstractMessageHandler<CreateLightstoneDataProvider>
    {
        private IRepository<State> _stateRepository;
        private IDataProviderRepository _dataProviderRepository;
        private IHandleMessages _createDataProviderHandler;

        public CreateLightstoneDataProviderHandler(IHandleMessages createDataProviderHandler, IRepository<State> stateRepository, IDataProviderRepository dataProviderRepository)
        {
            _createDataProviderHandler = createDataProviderHandler;
            _stateRepository = stateRepository;
            _dataProviderRepository = dataProviderRepository;
        }

        public override void Handle(CreateLightstoneDataProvider command)
        {
            if(_dataProviderRepository.FirstOrDefault(x => x.Name == DataProviderName.Lightstone) != null) //todo Refactor into repo
                return;

            var dataFields = Mapper.Map<IProvideDataFromLightstone, IEnumerable<IDataField>>(LightstoneResponseMother.Response);
            var state = _stateRepository.FirstOrDefault(x => x.Name == StateName.Draft); //todo Refactor into repo
            var createCommand = new CreateDataProvider(Guid.NewGuid(), DataProviderName.Lightstone, DataProviderName.Lightstone.ToString(), 0d, "http://test", typeof(IProvideDataFromLightstone), state, "Owner", DateTime.Now, dataFields);

            _createDataProviderHandler.Handle(createCommand);
        }
    }
}