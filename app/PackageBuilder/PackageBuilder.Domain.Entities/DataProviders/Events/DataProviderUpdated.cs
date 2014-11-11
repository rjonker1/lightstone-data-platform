using System;
using System.Collections.Generic;
using DataPlatform.Shared.Entities;
using DataPlatform.Shared.Enums;

namespace PackageBuilder.Domain.Entities.DataProviders.Events
{
    public class DataProviderUpdated : DataProviderCreated
    {
        public bool FieldLevelCostPriceOverride;
        public DataProviderUpdated(Guid id, DataProviderName name, string description, double costPrice, string sourceUrl, Type responseType, bool fieldLevelCostPriceOverride, int version, string owner, DateTime createdDate, DateTime editedDate, IEnumerable<IDataField> dataFields)
            : base(id, name, description, costPrice, sourceUrl, responseType, owner, createdDate, editedDate, dataFields)
        {
            Version = version;
            FieldLevelCostPriceOverride = fieldLevelCostPriceOverride;
        }
    }
}