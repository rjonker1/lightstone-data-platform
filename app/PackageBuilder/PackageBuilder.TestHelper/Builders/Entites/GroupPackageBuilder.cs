using System;
using PackageBuilder.Domain.Entities;
using PackageBuilder.Domain.Entities.Packages.WriteModels;

namespace PackageBuilder.TestHelper.Builders.Entites
{
    public class GroupPackageBuilder
    {
        private IPackage _package;
        private ICustomer _customer;
        private IGroup _group;
        public IGroupPackage Build()
        {
            return new GroupPackage(Guid.NewGuid(), _package, _customer, _group, new DateTime(2014, 01, 01));
        }

        public GroupPackageBuilder With(IPackage package)
        {
            _package = package;
            return this;
        }

        public GroupPackageBuilder With(ICustomer customer)
        {
            _customer = customer;
            return this;
        }

        public GroupPackageBuilder With(IGroup @group)
        {
            _group = group;
            return this;
        }
    }
}