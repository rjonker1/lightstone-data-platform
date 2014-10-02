using System;
using PackageBuilder.Core.Helpers.Cqrs.NEventStore;
using PackageBuilder.Domain.DataFields.WriteModels;
using PackageBuilder.Domain.MessageHandling;

namespace PackageBuilder.Domain.DataFields.Events.Handlers
{
    public class DataFieldRevisionCreatedHandler : AbstractMessageHandler<DataFieldRevisionCreated>
    {
        private readonly IRepository<DataField> _repository;

        public DataFieldRevisionCreatedHandler(IRepository<DataField> repository)
        {
            _repository = repository;
        }

        public override void Handle(DataFieldRevisionCreated domainCommand)
        {
            //var entity = new DataField(domainCommand.Id, domainCommand.Name, domainCommand.Type, domainCommand.DataProviderId);

            //_repository.Save(entity, Guid.NewGuid());
        }
    }
}