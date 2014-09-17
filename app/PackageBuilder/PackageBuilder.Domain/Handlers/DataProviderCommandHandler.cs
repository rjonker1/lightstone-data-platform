using PackageBuilder.Domain.Commands;
using PackageBuilder.Domain.Entities;
using PackageBuilder.Domain.Repositories;

namespace PackageBuilder.Domain.Handlers
{
    public class DataProviderCommandHandler : BaseCommandHandler<CreateDataProviderCommand>
    {
        private readonly IRepository<DataProvider> _repository;

        public override void Handle(CreateDataProviderCommand command)
        {
            var item = new DataProvider(command.Id, command.Name);
            _repository.Save(item, -1);
        }
    }
}