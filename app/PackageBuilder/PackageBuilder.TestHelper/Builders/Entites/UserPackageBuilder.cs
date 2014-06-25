using System;
using DataPlatform.Shared.Entities;
using PackageBuilder.Domain;
using PackageBuilder.Domain.Contracts;
using PackageBuilder.Domain.Entities;

namespace PackageBuilder.TestHelper.Builders.Entites
{
    public class UserPackageBuilder
    {
        public static IUserPackage Get(IPackage package, ICustomer customer, IUser user)
        {
            return new UserPackage(Guid.NewGuid(), package, customer, user, new DateTime(2014, 01, 01));
        }
    }
}