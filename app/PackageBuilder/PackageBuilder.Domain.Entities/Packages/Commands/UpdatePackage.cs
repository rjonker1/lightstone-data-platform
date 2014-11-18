using System;
using System.Collections.Generic;
using PackageBuilder.Domain.Entities.States.WriteModels;
using IDataProvider = PackageBuilder.Domain.Entities.DataProviders.WriteModels.IDataProvider;

namespace PackageBuilder.Domain.Entities.Packages.Commands
{
    public class UpdatePackage : CreatePackage
    {
        public readonly int Version;

        public UpdatePackage(Guid id, string name, string description, string industry, double costPrice, double salePrice, State state, int version, string owner, DateTime createdDate, DateTime editedDate, IEnumerable<IDataProvider> dataProviders)
            : base(id, name, description, industry, costPrice, salePrice, state, owner, createdDate, editedDate, dataProviders)
        {
            Version = version;
        }
    }
}
