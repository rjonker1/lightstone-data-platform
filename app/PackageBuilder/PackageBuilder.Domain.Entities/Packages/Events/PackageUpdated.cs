using System;
using System.Collections.Generic;
using DataPlatform.Shared.Entities;
using PackageBuilder.Domain.Entities.States.WriteModels;

namespace PackageBuilder.Domain.Entities.Packages.Events
{
    public class PackageUpdated : PackageCreated
    {
        public PackageUpdated(Guid id, string name, string description, double costPrice, double salePrice, State state, int version, decimal displayVersion, string owner, DateTime createdDate, DateTime? editedDate, IEnumerable<IDataProvider> dataProviders) 
            : base(id, name, description, costPrice, salePrice, state, displayVersion, owner, createdDate, editedDate, dataProviders)
        {
            Version = version;
        }
    }
}