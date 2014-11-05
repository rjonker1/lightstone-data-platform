using System.Linq;
using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using PackageBuilder.Core.MessageHandling;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Entities.Enums;
using PackageBuilder.Domain.Entities.Packages.Events;
using PackageBuilder.Domain.Entities.Packages.ReadModels;

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
            //todo: refactor into PackageRepo
            var existing = _repository.FirstOrDefault(x => x.Id != command.Id && x.Name.ToLower() == command.Name.ToLower() && x.State.Name == StateName.Published);
            if (existing != null)
                throw new LightstoneAutoException("A data provider with the name {0} already exists".FormatWith(command.Name));

            _repository.Save(new Package(command.Id, command.Name, command.Description, command.State, command.Version, command.DisplayVersion, command.Owner, command.CreatedDate, command.EditedDate));
        }
    }
}
