using System;
using CommonDomain.Persistence;
using PackageBuilder.Domain.DataProviders.Commands;
using PackageBuilder.Domain.Helpers.Cqrs.CommandHandling;

namespace PackageBuilder.Domain.DataProviders.Handlers
{
    public class CreateDataProviderCommandHandler : BaseCommandHandler<CreateDataProviderCommand>
    {
        private readonly IRepository _repository;

        public CreateDataProviderCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public override void Handle(CreateDataProviderCommand command)
        {
            var entity = new DataProvider(command.Id, command.Name);
            _repository.Save(typeof(DataProvider).Name, entity, Guid.NewGuid());
        }
    }
}