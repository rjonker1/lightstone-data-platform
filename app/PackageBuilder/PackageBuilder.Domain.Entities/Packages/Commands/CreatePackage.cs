using System;
using System.Collections.Generic;
using DataPlatform.Shared.Entities;
using PackageBuilder.Core.Commands;

namespace PackageBuilder.Domain.Entities.Packages.Commands
{
    public class CreatePackage : IDomainCommand
    {
        public Guid Id { get; private set; }
        public readonly string Name;
        public readonly string Description;
        public readonly string Owner;
        public readonly IEnumerable<IDataProvider> DataProviders;

        public CreatePackage(Guid id, string name, string description, IEnumerable<IDataProvider> dataProviders)
        {
            Id = id;
            Name = name;
            Description = description;
            DataProviders = dataProviders;
        }
    }
}