using System;
using System.Collections.Generic;
using PackageBuilder.Domain.Entities.Industries.WriteModels;
using PackageBuilder.Domain.Entities.States.WriteModels;
using IDataProvider = PackageBuilder.Domain.Entities.DataProviders.WriteModels.IDataProvider;

namespace PackageBuilder.Domain.Entities.Packages.Events
{
    public class PackageUpdated : PackageCreated
    {
        public PackageUpdated(Guid id, string name, string description, double costPrice, double salePrice, string notes, IEnumerable<Industry> industries, State state, int version, decimal displayVersion, string owner, DateTime createdDate, DateTime? editedDate, IEnumerable<IDataProvider> dataProviders) 
            : base(id, name, description, costPrice, salePrice, industries, state, displayVersion, owner, createdDate, editedDate, dataProviders)
        {
            Notes = notes;
            Version = version;
        }
    }
}