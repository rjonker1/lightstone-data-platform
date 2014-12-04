using System;
using System.Collections.Generic;
using DataPlatform.Shared.Enums;
using IDataField = PackageBuilder.Domain.Entities.DataFields.WriteModels.IDataField;

namespace PackageBuilder.Domain.Entities.DataProviders.Events
{
    public class DataProviderUpdated : DataProviderCreated
    {
        public bool FieldLevelCostPriceOverride;
        public DateTime? EditedDate;
        public DataProviderUpdated(Guid id, DataProviderName name, string description, double costPrice, Type responseType, bool fieldLevelCostPriceOverride, int version, string owner, DateTime createdDate, DateTime? editedDate, IEnumerable<IDataField> dataFields)
            : base(id, name, description, costPrice, responseType, owner, createdDate, dataFields)
        {
            Version = version;
            FieldLevelCostPriceOverride = fieldLevelCostPriceOverride;
            EditedDate = editedDate;
        }
    }
}