using System;
using System.Collections.Generic;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.Helpers.Extensions;
using PackageBuilder.Domain.Entities.Contracts.DataProviders.Write;
using PackageBuilder.Domain.Entities.Industries.Read;
using PackageBuilder.Domain.Entities.States.Read;

namespace PackageBuilder.Domain.Entities.Packages.Commands
{
    public class UpdatePackage : CreatePackage
    {
        public readonly int Version;

        public UpdatePackage(Guid id, string name, string description, decimal costPrice, decimal salePrice, string notes, PackageEventType? packageEventType, IEnumerable<Industry> industries, State state, int version, string owner, DateTime createdDate, DateTime editedDate, IEnumerable<IDataProviderOverride> dataProviderValueOverrides)
            : base(id, name, description, costPrice, salePrice, notes, packageEventType, industries, state, owner, createdDate, editedDate, dataProviderValueOverrides)
        {
            Version = version;
        }

        public override string ToString()
        {
            return "{0} - {1} - {2}".FormatWith(Id, Name, GetType());
        }
    }
}
