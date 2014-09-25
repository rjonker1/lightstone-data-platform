using System;
using CommonDomain.Persistence;
using PackageBuilder.Domain.DataProviders.WriteModels;
using PackageBuilder.Domain.Helpers.Cqrs.NEventStore;
using PackageBuilder.Domain.Helpers.MessageHandling;

namespace PackageBuilder.Domain.DataProviders.Commands.Handlers
{
    public class CreateDataProviderRevisionHandler : AbstractMessageHandler<CreateDataProviderRevision>
    {
        private readonly IRepository _repository;

        public CreateDataProviderRevisionHandler(IRepository<DataProvider> repository)
        {
            _repository = repository;
        }

        public override void Handle(CreateDataProviderRevision command)
        {
            var entity = _repository.GetById<DataProvider>(command.Id);
            entity.CreateDataProviderRevision(command.Id, command.Name, command.DataProviderType, command.DataFields);
            _repository.Save(typeof(DataProvider).Name, entity, Guid.NewGuid());
        }
    }
}