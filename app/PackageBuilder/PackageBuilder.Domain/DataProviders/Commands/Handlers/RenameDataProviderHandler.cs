using System;
using CommonDomain.Persistence;
using PackageBuilder.Domain.DataProviders.WriteModels;
using PackageBuilder.Domain.Helpers.MessageHandling;

namespace PackageBuilder.Domain.DataProviders.Commands.Handlers
{
    public class RenameDataProviderHandler : AbstractMessageHandler<RenameDataProvider>
    {
        private readonly IRepository _repository;

        public RenameDataProviderHandler(IRepository repository)
        {
            _repository = repository;
        }

        public override void Handle(RenameDataProvider command)
        {
            var entity = _repository.GetById<DataProvider>(command.Id);
            entity.ChangeName(command.NewName);
            _repository.Save(typeof(DataProvider).Name, entity, Guid.NewGuid());
        }
    }
}