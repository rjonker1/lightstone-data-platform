using System.Linq;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;

namespace Lace.Domain.DataProviders.Core.Shared
{
    public sealed class CheckThePackageDataSource : ICheckThePackageDataSource
    {

        private static readonly ICheckThePackageDataSource PackageDataSourceCheck = new CheckThePackageDataSource();

        public static ICheckThePackageDataSource PackageDataSourceChecks
        {
            get
            {
                return PackageDataSourceCheck;
            }
        }

        public bool CheckIfPackageRequiresDataProvider(IHavePackageForRequest package, DataProviderName dataProvider)
        {
            if (package == null || package.DataProviders == null || !package.DataProviders.Any()) return false;

            return package.DataProviders.SingleOrDefault(f => f.Name == dataProvider) != null;
        }
    }
}
