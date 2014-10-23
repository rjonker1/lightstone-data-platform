using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Entities.Packages.Events;
using PackageBuilder.Domain.Entities.Packages.ReadModels;
using PackageBuilder.Domain.MessageHandling;

namespace PackageBuilder.Domain.EventHandlers.Packages
{
    public class PackageCreatedHandler : AbstractMessageHandler<PackageCreated>
    {
        private readonly IRepository<Package> _repository;

        public PackageCreatedHandler(IRepository<Package> repository)
        {
            _repository = repository;
        }

        public override void Handle(PackageCreated command)
        {
            _repository.Save(new Package(command.Id, command.Name, command.Description, command.Version, command.Owner, command.CreatedDate, command.EditedDate));
        }
    }
}
