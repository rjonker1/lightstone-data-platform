using System;
using DataPlatform.Shared.Entities;
using PackageBuilder.Domain.Contracts;
using PackageBuilder.Domain.Contracts.Enitities;
using PackageBuilder.Domain.Entities;

namespace PackageBuilder.TestHelper.Builders.Entites
{
    public class UserPackageBuilder
    {
        private ICustomer _customer;
        private IUser _user;
        private IPackage _package;
        public IUserPackage Build()
        {
            return new UserPackage(Guid.NewGuid(), _package, _customer, _user, new DateTime(2014, 01, 01));
        }

        public UserPackageBuilder With(ICustomer customer)
        {
            _customer = customer;
            return this;
        }

        public UserPackageBuilder With(IUser user)
        {
            _user = user;
            return this;
        }

        public UserPackageBuilder With(IPackage package)
        {
            _package = package;
            return this;
        }
    }
}