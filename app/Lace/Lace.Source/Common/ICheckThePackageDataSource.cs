using System;
using DataPlatform.Shared.Entities;

namespace Lace.Source.Common
{
    public interface ICheckThePackageDataSource
    {
        bool CheckIfPackageDataSourceRequiresService(IPackage package, Guid serviceId);
    }
}
