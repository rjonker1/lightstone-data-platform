using System;
using System.Collections.Generic;
using DataPlatform.Shared.Enums;
using PackageBuilder.Domain.Entities.Contracts.DataProviders.Write;
using PackageBuilder.Domain.Entities.Industries.Read;
using PackageBuilder.Domain.Entities.States.Read;

namespace PackageBuilder.Domain.Entities.Packages.Events
{
    public class PackageUpdated : PackageCreated
    {
        public PackageUpdated(Guid id, string name, string description, decimal costPrice, decimal salePrice, string notes, PackageEventType? packageEventType, IEnumerable<Industry> industries, State state, int version, decimal displayVersion, string owner, DateTime createdDate, DateTime? editedDate, IEnumerable<IDataProviderOverride> dataProviderValueOverrides)
            : base(id, name, description, costPrice, salePrice, packageEventType, industries, state, displayVersion, owner, createdDate, editedDate, dataProviderValueOverrides)
        {
            Notes = notes;
            Version = version;
        }
    }
}