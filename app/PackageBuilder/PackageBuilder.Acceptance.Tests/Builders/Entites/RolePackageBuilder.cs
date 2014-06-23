using System;
using DataPlatform.Shared.Entities;
using PackageBuilder.Api.CannedData;

namespace PackageBuilder.Acceptance.Tests.Builders.Entites
{
    public class RolePackageBuilder
    {
        public static IRolePackage Get(IPackage package, ICustomer customer, IRole role)
        {
            return new RolePackage(Guid.NewGuid(), package, customer, role, new DateTime(2014, 01, 01));
        }
    }
}