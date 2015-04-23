using System.Collections.Generic;
using PackageBuilder.Core.Entities;
using PackageBuilder.Domain.Entities.Contracts.Industries.Read;

namespace PackageBuilder.Domain.Entities.Contracts.DataFields.Write
{
    public interface IDataField : INamedEntity
    {
        string Namespace { get; set; }
        string Label { get; }
        string Value { get; }
        string Definition { get; }
        IEnumerable<IIndustry> Industries { get; }
        double CostOfSale { get; }
        bool? IsSelected { get; }
        int Order { get; }
        string Type { get; }
        IEnumerable<IDataField> DataFields { get; }
        void OverrideValuesFromPackage(double costPrice, bool? selected);
    }
}