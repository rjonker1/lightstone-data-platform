using System;
using System.Collections.Generic;
using DataPlatform.Shared.Entities;

namespace PackageBuilder.Domain.Entities.Packages.Events
{
    public class PackageUpdated : PackageCreated
    {
        public PackageUpdated(Guid id, string name, IEnumerable<IDataProvider> dataProviders) : base(id, name, dataProviders)
        {
        }
    }
}