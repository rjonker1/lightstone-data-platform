using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PackageBuilder.Core.MessageHandling;
using PackageBuilder.Domain.CommandHandlers.DataProviders.Responses;
using PackageBuilder.Domain.Entities;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.DataFields.Write;
using PackageBuilder.Domain.Entities.DataProviders.Commands;
using PackageBuilder.Domain.Entities.DataProviders.Write;
using PackageBuilder.Infrastructure.NEventStore;

namespace PackageBuilder.Domain.CommandHandlers.DataProviders
{
    public class AmendDataProviderStructureHandler : AbstractMessageHandler<AmendDataProviderStructure>
    {
        private readonly INEventStoreRepository<DataProvider> _writeRepo;
        private readonly IAmDataProviderResponseRepository _dataProviderResponseRepository;

        public AmendDataProviderStructureHandler(INEventStoreRepository<DataProvider> writeRepo, IAmDataProviderResponseRepository dataProviderResponseRepository)
        {
            _writeRepo = writeRepo;
            _dataProviderResponseRepository = dataProviderResponseRepository;
        }

        public override void Handle(AmendDataProviderStructure command)
        {
            var existing = _writeRepo.GetById(command.Id);
            var response = _dataProviderResponseRepository.GetDataProvider(existing.Name);
            var requestFields = Mapper.Map(response, response.GetType(), typeof(IEnumerable<IDataField>)) as IEnumerable<IDataField>;
            var dataFields = Mapper.Map(response, response.GetType(), typeof(IEnumerable<DataField>)) as IEnumerable<DataField>;
            var entity = new DataProvider(existing.Id, existing.Name, existing.Name.ToString(), 0, response.GetType(), "", DateTime.UtcNow, requestFields, dataFields, existing.Version + 1);

            existing.DataFields.ToNamespace().Cast<DataField>()
                               .RecursiveForEach(oldField =>
                               {
                                   var newField = entity.DataFields.ToNamespace().Cast<DataField>().Filter(f => oldField != null && f.Namespace == oldField.Namespace).FirstOrDefault();
                                   if (newField != null)
                                       Mapper.Map(oldField, newField, typeof(DataField), typeof(DataField));
                               });

            _writeRepo.Save(entity, Guid.NewGuid());
        }
    }
}