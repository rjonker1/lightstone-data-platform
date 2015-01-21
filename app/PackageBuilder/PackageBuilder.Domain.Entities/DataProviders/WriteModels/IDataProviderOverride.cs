using System;
using System.Collections.Generic;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;

namespace PackageBuilder.Domain.Entities.DataProviders.WriteModels
{
    public interface IDataProviderOverride
    {
        Guid Id { get; }
        double CostOfSale { get; }
        IEnumerable<IDataFieldOverride> DataFieldOverrides { get; }
    }
}