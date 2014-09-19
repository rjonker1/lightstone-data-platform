using System;
using CommonDomain.Persistence;
using PackageBuilder.Domain.DataProviders.WriteModels;
using PackageBuilder.Domain.Helpers.MessageHandling;

namespace PackageBuilder.Domain.DataFields.Commands.Handlers
{
    public class RenameDataFieldHandler : AbstractMessageHandler<RenameDataField>
    {
        private readonly IRepository _repository;

        public RenameDataFieldHandler(IRepository repository)
        {
            _repository = repository;
        }

        public override void Handle(RenameDataField domainCommand)
        {
            var entity = _repository.GetById<DataProvider>(domainCommand.Id);
            entity.ChangeName(domainCommand.NewName);
            _repository.Save(typeof(DataProvider).Name, entity, Guid.NewGuid());
        }
    }
}