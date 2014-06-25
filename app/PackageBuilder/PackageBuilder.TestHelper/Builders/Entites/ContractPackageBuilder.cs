using System;
using DataPlatform.Shared.Entities;
using PackageBuilder.Domain;
using PackageBuilder.Domain.Contracts;
using PackageBuilder.Domain.Entities;

namespace PackageBuilder.TestHelper.Builders.Entites
{
    public class ContractPackageBuilder
    {
        public static IContractPackage Get(IPackage package, IContract contract)
        {
            return new ContractPackage(Guid.NewGuid(), package, contract, new DateTime(2014, 01, 01));
        }
    }
}