﻿using System;
using System.Collections.Generic;
using DataPlatform.Shared.Enums;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;

namespace PackageBuilder.Domain.Entities.DataProviders.Events
{
    public class DataProviderUpdated : DataProviderCreated
    {
        public bool FieldLevelCostPriceOverride;
        public DateTime? EditedDate;
        public DataProviderUpdated(Guid id, DataProviderName name, string description, decimal costPrice, Type responseType, bool fieldLevelCostPriceOverride, int version, string owner, DateTime createdDate, DateTime? editedDate, IEnumerable<IDataField> requestFields, IEnumerable<IDataField> dataFields)
            : base(id, name, description, costPrice, responseType, owner, createdDate, requestFields, dataFields)
        {
            Version = version;
            FieldLevelCostPriceOverride = fieldLevelCostPriceOverride;
            EditedDate = editedDate;
        }
    }
}