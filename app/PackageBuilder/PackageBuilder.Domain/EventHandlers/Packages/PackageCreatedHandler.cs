using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using PackageBuilder.Core.MessageHandling;
using PackageBuilder.Domain.Entities.Packages.Events;
using PackageBuilder.Domain.Entities.Packages.ReadModels;
using PackageBuilder.Infrastructure.Repositories;

namespace PackageBuilder.Domain.EventHandlers.Packages
{
    public class PackageCreatedHandler : AbstractMessageHandler<PackageCreated>
    {
        private readonly IPackageRepository _repository;

        public PackageCreatedHandler(IPackageRepository repository)
        {
            _repository = repository;
        }

        public override void Handle(PackageCreated command)
        {
            if (_repository.Exists(command.Id, command.Name))
                throw new LightstoneAutoException("A Package with the name {0} already exists".FormatWith(command.Name));

            _repository.Save(new Package(command.Id, command.Name, command.Description, command.State, command.Version, command.DisplayVersion, command.Owner, command.CreatedDate, command.EditedDate));
        }
    }
}
