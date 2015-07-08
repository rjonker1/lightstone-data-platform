using System.Collections.Generic;
using PackageBuilder.Core.Entities;

namespace PackageBuilder.Domain.Entities.Contracts.DataFields.Write
{
    public interface IDataFieldOverride : INamedEntity
    {
        string Namespace { get; set; }
        string DisplayName { get; }
        double CostOfSale { get; }
        bool? IsSelected { get; }
        int Order { get; }
        IEnumerable<IDataFieldOverride> RequestFieldOverrides { get; set; }
        IEnumerable<IDataFieldOverride> DataFieldOverrides { get; set; }
    }
}