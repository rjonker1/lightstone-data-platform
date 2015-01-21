using System.Collections.Generic;

namespace PackageBuilder.Domain.Entities.DataFields.WriteModels
{
    public interface IDataFieldOverride
    {
        string Name { get; }
        string Namespace { get; set; }
        string DisplayName { get; }
        double CostOfSale { get; }
        bool? IsSelected { get; }
        int Order { get; }
        IEnumerable<IDataFieldOverride> DataFieldOverrides { get; set; }
    }
}