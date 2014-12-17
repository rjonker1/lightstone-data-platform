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
        public double CostOfSale;
        public IEnumerable<DataFieldOverride> DataFieldOverrides;
    }
}