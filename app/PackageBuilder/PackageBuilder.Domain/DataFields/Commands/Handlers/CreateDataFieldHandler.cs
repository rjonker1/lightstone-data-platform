using PackageBuilder.Core.NEventStore;
using PackageBuilder.Domain.DataFields.WriteModels;
using PackageBuilder.Domain.MessageHandling;

namespace PackageBuilder.Domain.DataFields.Commands.Handlers
{
    public class CreateDataFieldHandler : AbstractMessageHandler<CreateDataField>
    {
        private readonly INEventStoreRepository<DataField> _repository;

        public CreateDataFieldHandler(INEventStoreRepository<DataField> repository)
        {
            _repository = repository;
        }

        public override void Handle(CreateDataField domainCommand)
        {
            //var entity = new DataField(domainCommand.Id, domainCommand.Name, domainCommand.Type, domainCommand.DataProviderId);

            //_repository.Save(entity, Guid.NewGuid());
        }
    }
}