using System;
using System.Collections.Generic;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;

namespace PackageBuilder.Domain.Entities.Contracts.DataProviders.Write
{
    public interface IDataProviderOverride
    {
        Guid Id { get; }
        decimal CostOfSale { get; }
        IEnumerable<IDataFieldOverride> RequestFieldOverrides { get; }
        IEnumerable<IDataFieldOverride> DataFieldOverrides { get; }
    }
}