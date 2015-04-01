using Lace.Domain.Core.Requests.Contracts;
using PackageBuilder.Domain.Entities.Enums.DataProviders;

namespace Lace.Domain.DataProviders.Core.Contracts
{
    public interface ICheckThePackageDataSource
    {
        bool CheckIfPackageRequiresDataProvider(IAmPackageForRequest package, DataProviderName dataProvider);
    }
}
