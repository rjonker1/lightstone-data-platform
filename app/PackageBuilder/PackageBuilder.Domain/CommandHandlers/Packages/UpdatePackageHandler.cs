using System;
using System.Linq;
using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Entities.Enums;
using PackageBuilder.Domain.Entities.Packages.Commands;
using PackageBuilder.Domain.Entities.Packages.WriteModels;
using PackageBuilder.Domain.MessageHandling;

namespace PackageBuilder.Domain.CommandHandlers.Packages
{
    public class UpdatePackageHandler : AbstractMessageHandler<UpdatePackage>
    {
         private readonly INEventStoreRepository<Package> _writeRepo;
         private readonly IRepository<Entities.Packages.ReadModels.Package> _readRepo;


        public UpdatePackageHandler(INEventStoreRepository<Package> writeRepo, IRepository<Entities.Packages.ReadModels.Package> readRepo)
        {
            _writeRepo = writeRepo;
            _readRepo = readRepo;
        }

        public override void Handle(UpdatePackage command)
        {
            var existing = _readRepo.FirstOrDefault(x => x.Id != command.Id && x.Name.ToLower() == command.Name.ToLower() && x.State.Name == StateName.Published);
            if (existing != null)
                throw new LightstoneAutoException("A data provider with the name {0} already exists".FormatWith(command.Name));

            var name = command.Name;

            var entity = _writeRepo.GetById(command.Id);
            if (entity.State.Name == StateName.Published) // Name should not be editable after published
                name = entity.Name;

            entity.CreatePackageRevision(command.Id, name, command.Description, command.CostPrice,
                command.SalePrice, command.State, command.Owner,
                command.CreatedDate, command.EditedDate, command.DataProviders);

            _writeRepo.Save(entity, Guid.NewGuid());
        }
    }
}
