using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Requests.Contracts;

namespace Lace.Domain.DataProviders.Core.Contracts
{
    public interface ICheckThePackageDataSource
    {
        bool CheckIfPackageRequiresDataProvider(IHavePackageForRequest package, DataProviderName dataProvider);
    }
}
