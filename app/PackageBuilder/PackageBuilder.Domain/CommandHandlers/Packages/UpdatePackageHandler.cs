using System;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Domain.Entities.Packages.Commands;
using PackageBuilder.Domain.Entities.Packages.WriteModels;
using PackageBuilder.Domain.MessageHandling;

namespace PackageBuilder.Domain.CommandHandlers.Packages
{
    public class UpdatePackageHandler : AbstractMessageHandler<UpdatePackage>
    {
         private readonly INEventStoreRepository<Package> _repository;

        public UpdatePackageHandler(INEventStoreRepository<Package> repository)
        {
            _repository = repository;
        }

        public override void Handle(UpdatePackage command)
        {
            var entity = _repository.GetById(command.Id);
            entity.CreatePackageRevision(command.Id, command.Name, command.Description, command.CostPrice,
                command.SalePrice, command.State, command.Owner,
                command.CreatedDate, command.EditedDate, command.DataProviders);
            _repository.Save(entity, Guid.NewGuid());
        }
    }
}
