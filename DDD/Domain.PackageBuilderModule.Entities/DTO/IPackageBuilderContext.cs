using System.CodeDom.Compiler;
using System.Collections.Generic;

namespace LightstoneApp.Domain.PackageBuilderModule.Entities.DTO
{
    [GeneratedCode("OIALtoPLiX", "1.0")]
    public interface IPackageBuilderContext
    {
        IEnumerable<PackageBuilder.Package> PackageCollection { get; }
        IEnumerable<State> StateCollection { get; }
        IEnumerable<DataProvider> DataProviderCollection { get; }
        IEnumerable<DataField> DataFieldCollection { get; }
        IEnumerable<PackageDataField> PackageDataFieldCollection { get; }
        IEnumerable<Industry> IndustryCollection { get; }
        PackageBuilder.Package GetPackageByExternalUniquenessConstraint2(string Name, string Version);

        bool TryGetPackageByExternalUniquenessConstraint2(string Name, string Version,
            out PackageBuilder.Package Package);

        DataProvider GetDataProviderByExternalUniquenessConstraint1(string Name, string Version);

        bool TryGetDataProviderByExternalUniquenessConstraint1(string Name, string Version,
            out DataProvider DataProvider);

        DataField GetDataFieldByName(string Name);
        bool TryGetDataFieldByName(string Name, out DataField DataField);
        PackageBuilder.Package CreatePackage(string Name, string Description, string Version, State State);
        State CreateState(string Value);
        DataProvider CreateDataProvider(string Name, string Owner, string Version, string SourceURL, State State);

        DataField CreateDataField(bool Selected, decimal CostOfSale, string Name, DataProvider DataProvider,
            Industry Industry);

        PackageDataField CreatePackageDataField(int Priority, string UnifiedName, bool Selected,
            PackageBuilder.Package Package, DataField DataField);

        Industry CreateIndustry(string Value);
    }
}