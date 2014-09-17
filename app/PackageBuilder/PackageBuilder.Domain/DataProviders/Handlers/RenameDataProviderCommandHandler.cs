using System;
using CommonDomain.Persistence;
using PackageBuilder.Domain.DataProviders.Commands;
using PackageBuilder.Domain.Helpers.Cqrs.CommandHandling;

namespace PackageBuilder.Domain.DataProviders.Handlers
{
    public class RenameDataProviderCommandHandler : BaseCommandHandler<RenameDataProviderCommand>
    {
        private readonly IRepository _repository;

        public RenameDataProviderCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public override void Handle(RenameDataProviderCommand command)
        {
            var entity = _repository.GetById<DataProvider>(command.Id);
            entity.ChangeName(command.NewName);
            _repository.Save(typeof(DataProvider).Name, entity, Guid.NewGuid());
        }
    }
}