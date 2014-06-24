using System;
using DataPlatform.Shared.Entities;
using PackageBuilder.Domain;
using PackageBuilder.Domain.Contracts;
using PackageBuilder.Domain.Entities;

namespace PackageBuilder.TestHelper.Builders.Entites
{
    public class RolePackageBuilder
    {
        public static IRolePackage Get(IPackage package, ICustomer customer, IRole role)
        {
            return new RolePackage(Guid.NewGuid(), package, customer, role, new DateTime(2014, 01, 01));
        }
    }
}