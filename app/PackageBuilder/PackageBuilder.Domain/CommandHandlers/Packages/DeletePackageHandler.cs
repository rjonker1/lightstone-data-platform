using PackageBuilder.Core.MessageHandling;
using PackageBuilder.Domain.Entities.Packages.Commands;
using PackageBuilder.Infrastructure.Repositories;

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
            if (_repository.HasPublishedVersions(command.Id)) return;

            var packages = _repository.GetAllVersions(command.Id);
            if (packages == null) return;

            foreach (var package in packages)
                package.DeletePackage();
        }
    }
}