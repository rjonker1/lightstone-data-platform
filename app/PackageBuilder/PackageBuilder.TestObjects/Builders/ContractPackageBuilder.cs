using System;
using PackageBuilder.Domain.Entities;
using PackageBuilder.Domain.Entities.Packages.WriteModels;

namespace PackageBuilder.TestObjects.Builders
{
    public class ContractPackageBuilder
    {
        private IPackage _package;
        private IContract _contract;
        public IContractPackage Build()
        {
            return new ContractPackage(Guid.NewGuid(), _package, _contract, new DateTime(2014, 01, 01));
        }

        public ContractPackageBuilder With(IPackage package)
        {
            _package = package;
            return this;
        }

        public ContractPackageBuilder With(IContract contract)
        {
            _contract = contract;
            return this;
        }
    }
}