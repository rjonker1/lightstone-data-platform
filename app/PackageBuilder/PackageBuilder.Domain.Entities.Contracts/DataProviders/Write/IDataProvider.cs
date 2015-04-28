using System;
using System.Collections.Generic;
using DataPlatform.Shared.Enums;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;

namespace PackageBuilder.Domain.Entities.Contracts.DataProviders.Write
{
    public interface IDataProvider 
    {
        Guid Id { get; }
        DataProviderName Name { get; }
        string Description { get; }
        double CostOfSale { get; }
        ISourceConfiguration SourceConfiguration { get; }
        Type ResponseType { get; }
        bool FieldLevelCostPriceOverride { get; }
        int Version { get; }
        string Owner { get; }
        DateTime CreatedDate { get; }
        DateTime? EditedDate { get; }
        IEnumerable<IDataField> RequestFields { get; }
        IEnumerable<IDataField> DataFields { get; }

        void OverrideCostValuesFromPackage(double costOfSale);
    }
}