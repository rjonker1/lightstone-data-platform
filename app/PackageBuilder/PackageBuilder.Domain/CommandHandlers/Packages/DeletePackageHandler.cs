using System.Linq;
using PackageBuilder.Core.MessageHandling;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Entities.Enums;
using PackageBuilder.Domain.Entities.Packages.Commands;
using PackageBuilder.Domain.Entities.Packages.ReadModels;

namespace PackageBuilder.Domain.CommandHandlers.Packages
{
    public class DeletePackageHandler : AbstractMessageHandler<DeletePackage>
    {
        private readonly IRepository<Package> _repository;

        public DeletePackageHandler(IRepository<Package> repository)
        {
            _repository = repository;
        }

        public override void Handle(DeletePackage command)
        {
            if (_repository.Any(x => x.PackageId == command.Id && x.State.Name == StateName.Published))
                return;

            var packages = _repository.Where(x => x.PackageId == command.Id);

            foreach (var package in packages)
                package.DeletePackage();
        }
    }
}