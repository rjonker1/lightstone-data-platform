﻿using System;
using System.Collections.Generic;
using DataPlatform.Shared.Enums;

namespace DataPlatform.Shared.Entities
{
    public interface IDataProvider 
    {
        DataProviderName Name { get; }
        string Description { get; }
        double CostOfSale { get; }
        string SourceURL { get; }
        Type ResponseType { get; }
        bool FieldLevelCostPriceOverride { get; }
        int Version { get; }
        string Owner { get; }
        DateTime CreatedDate { get; }
        DateTime? EditedDate { get; }
        IEnumerable<IDataField> DataFields { get; }
    }
}