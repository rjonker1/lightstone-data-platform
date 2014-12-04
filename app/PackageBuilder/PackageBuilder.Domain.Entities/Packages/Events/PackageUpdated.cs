using System;
using System.Collections.Generic;
using PackageBuilder.Domain.Entities.Industries.WriteModels;
using PackageBuilder.Domain.Entities.States.WriteModels;
using IDataProvider = PackageBuilder.Domain.Entities.DataProviders.WriteModels.IDataProvider;

namespace PackageBuilder.Domain.Entities.Packages.Events
{
    public class PackageUpdated : PackageCreated
    {
        public PackageUpdated(Guid id, string name, string description, IEnumerable<Industry> industries, double costPrice, double salePrice, State state, int version, decimal displayVersion, string owner, DateTime createdDate, DateTime? editedDate, IEnumerable<IDataProvider> dataProviders) 
            : base(id, name, description, industries, costPrice, salePrice, state, displayVersion, owner, createdDate, editedDate, dataProviders)
        {
            Version = version;
        }
    }
}