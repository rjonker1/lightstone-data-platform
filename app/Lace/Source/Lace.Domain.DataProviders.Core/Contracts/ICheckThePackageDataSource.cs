using System;
using DataPlatform.Shared.Entities;

namespace Lace.Domain.DataProviders.Core.Contracts
{
    public interface ICheckThePackageDataSource
    {
        bool CheckIfPackageDataSourceRequiresService(IPackage package, Guid serviceId);
    }
}
