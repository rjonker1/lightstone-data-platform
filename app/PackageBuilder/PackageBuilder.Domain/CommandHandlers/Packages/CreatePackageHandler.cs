﻿using System;
using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using PackageBuilder.Core.MessageHandling;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Domain.Entities.Packages.Commands;
using PackageBuilder.Domain.Entities.Packages.Write;
using PackageBuilder.Infrastructure.Repositories;

namespace PackageBuilder.Domain.CommandHandlers.Packages
{
    public class CreatePackageHandler : AbstractMessageHandler<CreatePackage>
    {
        private readonly INEventStoreRepository<Package> _writeRepo;
        private readonly IPackageRepository _readRepo;

        public CreatePackageHandler(INEventStoreRepository<Package> writeRepo, IPackageRepository readRepo)
        {
            _writeRepo = writeRepo;
            _readRepo = readRepo;
        }

        public override void Handle(CreatePackage command)
        {
            if (command.Name == null)
                throw new LightstoneAutoException("Package name was not specified.");

            var exists = _readRepo.Exists(command.Id, command.Name);
            if (exists)
            {
                throw new LightstoneAutoException("A Package with the name {0} already exists".FormatWith(command.Name));
                this.Warn(() => "A Package with the name {0} already exists".FormatWith(command.Name));
                return;
            }

            var entity = new Package(command.Id, command.Name, command.Description, command.PackageEventType, command.Industries, command.CostPrice, command.SalePrice,
                command.State, 0.1M, command.Owner, command.CreatedDate, command.EditedDate, command.DataProviderValueOverrides);

            _writeRepo.Save(entity, Guid.NewGuid(), true);
        }
    }
}