using System.Collections.Generic;

namespace PackageBuilder.Domain.Entities.DataFields.WriteModels
{
    /// <summary>
    /// Overrides data field values on package level
    /// </summary>
    public class DataFieldOverride
    {
        public string Name;
        public string Namespace;
        public string DisplayName;
        public double CostOfSale;
        public bool? IsSelected;
        public int Order;
        public IEnumerable<DataFieldOverride> DataFieldOverrides { get; set; }
    }
}