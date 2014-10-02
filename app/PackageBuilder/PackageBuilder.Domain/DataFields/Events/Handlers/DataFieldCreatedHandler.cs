using System;
using PackageBuilder.Core.Helpers.Cqrs.NEventStore;
using PackageBuilder.Domain.DataFields.WriteModels;
using PackageBuilder.Domain.MessageHandling;

namespace PackageBuilder.Domain.DataFields.Events.Handlers
{
    public class DataFieldCreatedHandler : AbstractMessageHandler<DataFieldCreated>
    {
        private readonly IRepository<DataField> _repository;

        public DataFieldCreatedHandler(IRepository<DataField> repository)
        {
            _repository = repository;
        }

        public override void Handle(DataFieldCreated domainCommand)
        {
            //var entity = new DataField(domainCommand.Id, domainCommand.Name, domainCommand.Type, domainCommand.DataProviderId);

            //_repository.Save(entity, Guid.NewGuid());
        }
    }
}