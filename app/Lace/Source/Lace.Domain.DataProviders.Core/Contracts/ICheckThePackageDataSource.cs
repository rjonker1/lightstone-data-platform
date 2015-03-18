using PackageBuilder.Domain.Entities.Contracts.Packages.Write;
using PackageBuilder.Domain.Entities.Enums.DataProviders;

namespace Lace.Domain.DataProviders.Core.Contracts
{
    public interface ICheckThePackageDataSource
    {
        bool CheckIfPackageDataSourceRequiresService(IPackage package, DataProviderName dataProvider);
    }
}
