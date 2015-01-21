using System;
using System.Collections.Generic;
using DataPlatform.Shared.Helpers.Extensions;
using PackageBuilder.Domain.Entities.DataProviders.WriteModels;
using PackageBuilder.Domain.Entities.Industries.WriteModels;
using PackageBuilder.Domain.Entities.States.WriteModels;

namespace PackageBuilder.Domain.Entities.Packages.Commands
{
    public class UpdatePackage : CreatePackage
    {
        public readonly int Version;

        public UpdatePackage(Guid id, string name, string description, double costPrice, double salePrice, string notes, IEnumerable<Industry> industries, State state, int version, string owner, DateTime createdDate, DateTime editedDate, IEnumerable<DataProviderOverride> dataProviderValueOverrides)
            : base(id, name, description, costPrice, salePrice, notes, industries, state, owner, createdDate, editedDate, dataProviderValueOverrides)
        {
            Version = version;
        }

        public override string ToString()
        {
            return "{0} - {1} - {2}".FormatWith(Id, Name, GetType());
        }
    }
}
