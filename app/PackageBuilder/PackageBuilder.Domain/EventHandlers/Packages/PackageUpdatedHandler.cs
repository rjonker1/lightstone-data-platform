using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Entities.Packages.Events;
using PackageBuilder.Domain.Entities.Packages.ReadModels;
using PackageBuilder.Domain.MessageHandling;

namespace PackageBuilder.Domain.EventHandlers.Packages
{
    public class PackageUpdatedHandler : AbstractMessageHandler<PackageUpdated>
    {
        private readonly IRepository<Package> _repository;

        public PackageUpdatedHandler(IRepository<Package> repository)
        {
            _repository = repository;
        }

        public override void Handle(PackageUpdated command)
        {
            _repository.Save(new Package(command.Id, command.Name, command.Description, command.Version, command.Owner, command.CreatedDate, command.EditedDate));
        }
    }
}
