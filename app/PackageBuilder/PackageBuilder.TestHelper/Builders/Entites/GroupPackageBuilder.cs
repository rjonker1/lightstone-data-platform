using System;
using DataPlatform.Shared.Entities;
using PackageBuilder.Domain;
using PackageBuilder.Domain.Contracts;
using PackageBuilder.Domain.Entities;

namespace PackageBuilder.TestHelper.Builders.Entites
{
    public class GroupPackageBuilder
    {
        public static IGroupPackage Get(IPackage package, ICustomer customer, IGroup @group)
        {
            return new GroupPackage(Guid.NewGuid(), package, customer, @group, new DateTime(2014, 01, 01));
        }
    }
}