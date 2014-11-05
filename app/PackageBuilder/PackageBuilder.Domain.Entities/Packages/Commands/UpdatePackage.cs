using System;
using System.Collections.Generic;
using DataPlatform.Shared.Entities;
using PackageBuilder.Domain.Entities.States.WriteModels;

namespace PackageBuilder.Domain.Entities.Packages.Commands
{
    public class UpdatePackage : CreatePackage
    {
        public readonly int Version;

        public UpdatePackage(Guid id, string name, string description, double costPrice, double salePrice, State state, int version, string owner, DateTime createdDate, DateTime editedDate, IEnumerable<IDataProvider> dataProviders)
            : base(id, name, description, costPrice, salePrice, state, owner, createdDate, editedDate, dataProviders)
        {
            Version = version;
        }
    }
}
