using System;
using System.Collections.Generic;
using DataPlatform.Shared.Entities;

namespace PackageBuilder.Domain.Entities.DataProviders.Events
{
    public class DataProviderUpdated : DataProviderCreated
    {
        public DataProviderUpdated(Guid id, string name, string description, double costPrice, string sourceUrl, Type responseType, string state, string owner, DateTime createdDate, DateTime editedDate, IEnumerable<IDataField> dataFields) : base(id, name, description, costPrice, sourceUrl, responseType, state, owner, createdDate, editedDate, dataFields)
        {
        }
    }
}