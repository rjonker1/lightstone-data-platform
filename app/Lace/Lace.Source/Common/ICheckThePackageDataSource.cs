using DataPlatform.Shared.Public.Entities;

namespace Lace.Source.Common
{
    public interface ICheckThePackageDataSource
    {
        bool CheckIfPackageDataSourceRequiresService(IPackage package, int serviceId);
    }
}
