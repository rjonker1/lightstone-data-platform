using System;
using System.Collections.Generic;
using DataPlatform.Shared.Entities;

namespace PackageBuilder.Domain.Entities.Packages.Events
{
    public class PackageUpdated : PackageCreated
    {
        public PackageUpdated(Guid id, string name, string description, double costPrice, double salePrice, string state, string owner, DateTime createdDate, DateTime editedDate, IEnumerable<IDataProvider> dataProviders) 
            : base(id, name, description, costPrice, salePrice, state, owner, createdDate, editedDate, dataProviders)
        {
        }
    }
}