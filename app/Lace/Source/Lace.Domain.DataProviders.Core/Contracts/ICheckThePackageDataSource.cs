using DataPlatform.Shared.Enums;
using PackageBuilder.Domain.Entities.Packages.WriteModels;

namespace Lace.Domain.DataProviders.Core.Contracts
{
    public interface ICheckThePackageDataSource
    {
        bool CheckIfPackageDataSourceRequiresService(IPackage package, DataProviderName dataProvider);
    }
}
