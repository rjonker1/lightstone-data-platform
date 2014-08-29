using System;
using DataPlatform.Shared.Entities;
using PackageBuilder.Domain.Contracts;
using PackageBuilder.Domain.Contracts.Enitities;
using PackageBuilder.Domain.Entities;

namespace PackageBuilder.TestHelper.Builders.Entites
{
    public class RolePackageBuilder
    {
        private ICustomer _customer;
        private IPackage _package;
        private IRole _role;
        public IRolePackage Build()
        {
            return new RolePackage(Guid.NewGuid(), _package, _customer, _role, new DateTime(2014, 01, 01));
        }
        public RolePackageBuilder With(ICustomer customer)
        {
            _customer = customer;
            return this;
        }

        public RolePackageBuilder With(IPackage package)
        {
            _package = package;
            return this;
        }

        public RolePackageBuilder With(IRole role)
        {
            _role = role;
            return this;
        }
    }
}