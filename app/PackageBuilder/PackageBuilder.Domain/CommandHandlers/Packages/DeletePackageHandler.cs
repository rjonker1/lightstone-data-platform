using DataPlatform.Shared.Enums;
using DataPlatform.Shared.Helpers.Extensions;
using PackageBuilder.Core.MessageHandling;
using PackageBuilder.Domain.Entities.Packages.Commands;
using PackageBuilder.Infrastructure.Repositories;
using Shared.Logging;

namespace PackageBuilder.Domain.CommandHandlers.Packages
{
    public class DeletePackageHandler : AbstractMessageHandler<DeletePackage>
    {
        private readonly IPackageRepository _repository;

        public DeletePackageHandler(IPackageRepository repository)
        {
            _repository = repository;
        }

        public override void Handle(DeletePackage command)
        {
            if (_repository.HasPublishedVersions(command.Id))
            {
                this.Warn(() => "Package {0} may not be deleted if the package is or has previously been published".FormatWith(command.Id));
                return;
            }

            var packages = _repository.GetAllVersions(command.Id);
            if (packages == null)
            {
                this.Warn(() => "Could not retrieve package {0} rows to delete".FormatWith(command.Id));
                return;                
            }

            foreach (var package in packages)
                package.DeletePackage();
        }
    }
}