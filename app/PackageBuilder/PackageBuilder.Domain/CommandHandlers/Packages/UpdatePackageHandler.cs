using System;
using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using PackageBuilder.Core.MessageHandling;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Domain.Entities.Packages.Commands;
using PackageBuilder.Domain.Entities.Packages.WriteModels;
using PackageBuilder.Infrastructure.Repositories;

namespace PackageBuilder.Domain.CommandHandlers.Packages
{
    public class UpdatePackageHandler : AbstractMessageHandler<UpdatePackage>
    {
        private readonly INEventStoreRepository<Package> _writeRepo;
        private readonly IPackageRepository _readRepo;

        public UpdatePackageHandler(INEventStoreRepository<Package> writeRepo, IPackageRepository readRepo)
        {
            _writeRepo = writeRepo;
            _readRepo = readRepo;
        }

        public override void Handle(UpdatePackage command)
        {
            var exists = _readRepo.Exists(command.Id, command.Name);
            if (exists)
                throw new LightstoneAutoException("A data provider with the name {0} already exists".FormatWith(command.Name));

            var entity = _writeRepo.GetById(command.Id);
            entity.CreatePackageRevision(command.Id, command.Name, command.Description, command.CostPrice,
                command.SalePrice, command.Notes, command.Industries, command.State, command.Owner,
                command.CreatedDate, command.EditedDate, command.DataProviderValueOverrides);

            _writeRepo.Save(entity, Guid.NewGuid());
        }
    }
}
