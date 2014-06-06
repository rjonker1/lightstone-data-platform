﻿using System.Linq;
using DataPlatform.Shared.Public.Entities;


namespace Lace.Source.Common
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

        public bool CheckIfPackageDataSourceRequiresService(IPackage package, int serviceId)
        {
            if (package == null || package.DataSets == null) return false;

            foreach (var dataSet in package.DataSets)
            {
                if (dataSet.DataFields.FirstOrDefault(w => w.DataSource.Id == serviceId) != null) return true;
            }

            return false;
        }
    }
}