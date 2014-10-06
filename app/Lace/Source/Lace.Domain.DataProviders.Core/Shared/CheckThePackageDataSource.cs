using System;
using System.Linq;
using DataPlatform.Shared.Entities;
using Lace.Domain.DataProviders.Core.Contracts;

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

        public bool CheckIfPackageDataSourceRequiresService(IPackage package, Guid serviceId)
        {
            if (package == null || package.DataSets == null) return false;

            foreach (var dataSet in package.DataSets)
            {
                if (dataSet.DataFields.FirstOrDefault(w => w.DataProvider.Id == serviceId) != null) return true;
            }

            return false;
        }
    }
}
