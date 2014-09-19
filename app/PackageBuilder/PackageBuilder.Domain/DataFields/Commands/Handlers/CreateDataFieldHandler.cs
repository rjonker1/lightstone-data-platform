using System;
using PackageBuilder.Domain.DataFields.WriteModels;
using PackageBuilder.Domain.Helpers.Cqrs.NEventStore;
using PackageBuilder.Domain.Helpers.MessageHandling;

namespace PackageBuilder.Domain.DataFields.Commands.Handlers
{
    public class CreateDataFieldHandler : AbstractMessageHandler<CreateDataField>
    {
        private readonly IRepository<DataField> _repository;

        public CreateDataFieldHandler(IRepository<DataField> repository)
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