using System;
using System.Collections.Generic;
using DataPlatform.Shared.Enums;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;

namespace PackageBuilder.Domain.Entities.DataProviders.WriteModels
{
    public interface IDataProvider 
    {
        Guid Id { get; }
        DataProviderName Name { get; }
        string Description { get; }
        double CostOfSale { get; }
        SourceConfiguration SourceConfiguration { get; }
        Type ResponseType { get; }
        bool FieldLevelCostPriceOverride { get; }
        int Version { get; }
        string Owner { get; }
        DateTime CreatedDate { get; }
        DateTime? EditedDate { get; }
        IEnumerable<IDataField> DataFields { get; }

        void OverrideCostValuesFromPackage(double costOfSale);
    }
}