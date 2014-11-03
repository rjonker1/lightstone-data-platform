﻿using System;
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
    public class CreatePackageHandler : AbstractMessageHandler<CreatePackage>
    {
        private readonly INEventStoreRepository<Package> _writeRepo;
        private readonly IRepository<Entities.Packages.ReadModels.Package> _readRepo;

        public CreatePackageHandler(INEventStoreRepository<Package> writeRepo, IRepository<Entities.Packages.ReadModels.Package> readRepo)
        {
            _writeRepo = writeRepo;
            _readRepo = readRepo;
        }

        public override void Handle(CreatePackage command)
        {
            var existing = _readRepo.FirstOrDefault(x => x.Name.ToLower() == command.Name.ToLower() && x.State.Name == StateName.Published);
            if (existing != null)
                throw new LightstoneAutoException("A Package with the name {0} already exists".FormatWith(command.Name));

            var entity = new Package(command.Id, command.Name, command.Description, command.CostPrice, command.SalePrice,
                command.State, command.Owner, command.CreatedDate, command.EditedDate, command.DataProviders);

            _writeRepo.Save(entity, Guid.NewGuid());
        }
    }
}