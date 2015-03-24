using System.Linq;
using Lace.Domain.DataProviders.Core.Contracts;
using PackageBuilder.Domain.Entities.Contracts.Packages.Write;
using PackageBuilder.Domain.Entities.Enums.DataProviders;

namespace Lace.Domain.DataProviders.Core.Shared
{
    public class CheckThePackageDataSource : ICheckThePackageDataSource
    {

        private static readonly ICheckThePackageDataSource PackageDataSourceCheck =  new CheckThePackageDataSource();

        public static ICheckThePackageDataSource PackageDataSourceChecks
        {
            get
            {
                return PackageDataSourceCheck;
            }
        }

        public bool CheckIfPackageDataSourceRequiresService(IPackage package, DataProviderName dataProvider)
        {
            if (package == null || package.DataProviders == null || !package.DataProviders.Any()) return false;

            return package.DataProviders.FirstOrDefault(w => w.Name == dataProvider) != null;
        }
    }
}
