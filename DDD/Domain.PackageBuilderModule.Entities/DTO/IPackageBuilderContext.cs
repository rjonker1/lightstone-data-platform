using System.Collections.Generic;

namespace LightstoneApp.Domain.PackageBuilderModule.Entities.DTO
{
    public interface IPackageBuilderContext
    {
        PackageBuilder.Package GetPackageByPackageNameAndVersionExternalUniquenessConstraint(string Name, string Version);

        bool TryGetPackageByPackageNameAndVersionExternalUniquenessConstraint(string Name, string Version,
            out PackageBuilder.Package Package);

        DataProvider GetDataProviderByDataProviderNameAndVersionUniquenessConstraint(string Name, string Version);

        bool TryGetDataProviderByDataProviderNameAndVersionUniquenessConstraint(string Name, string Version,
            out DataProvider DataProvider);

        DataField GetDataFieldByName(string Name);
        bool TryGetDataFieldByName(string Name, out DataField DataField);
        PackageBuilder.Package CreatePackage(string name, string description, string version, State state);
        IEnumerable<PackageBuilder.Package> PackageCollection { get; }
        State CreateState(string value);
        IEnumerable<State> StateCollection { get; }
        DataProvider CreateDataProvider(string Name, string Owner, string Version, string SourceURL, State State);
        IEnumerable<DataProvider> DataProviderCollection { get; }

        DataField CreateDataField(bool Selected, decimal CostOfSale, string Name, DataProvider DataProvider,
            Industry Industry);

        IEnumerable<DataField> DataFieldCollection { get; }

        PackageDataField CreatePackageDataField(int Priority, string UnifiedName, bool Selected, PackageBuilder.Package Package,
            DataField DataField);

        IEnumerable<PackageDataField> PackageDataFieldCollection { get; }
        Industry CreateIndustry(string Value);
        IEnumerable<Industry> IndustryCollection { get; }
    }
}