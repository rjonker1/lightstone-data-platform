using System;
using System.Collections.Generic;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;

namespace PackageBuilder.Domain.Entities.DataProviders.WriteModels
{
    /// <summary>
    /// Overrides data provider values on package level
    /// </summary>
    public class DataProviderOverride
    {
        public Guid Id;
        public int Version;
        public double CostOfSale;
        public bool FieldLevelCostPriceOverride;
        public IEnumerable<DataFieldOverride> DataFieldValueOverrides;
    }
}