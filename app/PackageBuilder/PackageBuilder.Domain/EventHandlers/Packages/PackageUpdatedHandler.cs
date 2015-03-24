using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using PackageBuilder.Core.MessageHandling;
using PackageBuilder.Domain.Entities.Packages.Events;
using PackageBuilder.Domain.Entities.Packages.Read;
using PackageBuilder.Infrastructure.Repositories;

namespace PackageBuilder.Domain.EventHandlers.Packages
{
    public class PackageUpdatedHandler : AbstractMessageHandler<PackageUpdated>
    {
        private readonly IPackageRepository _repository;

        public PackageUpdatedHandler(IPackageRepository repository)
        {
            _repository = repository;
        }

        public override void Handle(PackageUpdated command)
        {
            if (_repository.Exists(command.Id, command.Name))
            {
                var exception = new LightstoneAutoException("A package with the name {0} already exists".FormatWith(command.Name));
                this.Warn(() => exception);
                throw exception;
            }

            _repository.Save(new Package(command.Id, command.Name, command.Description, command.State, command.Version, command.DisplayVersion, command.Owner, command.CreatedDate, command.EditedDate));
        }
    }
}
