using DataPlatform.Shared.Entities;
using PackageBuilder.Domain.Contracts;
using PackageBuilder.TestHelper.Fakes;

namespace PackageBuilder.TestHelper.Builders.Repositories
{
    public class ContractPackageRepositoryBuilder
    {
        public static IContractPackageRepository Get(params IContractPackage[] entities)
        {
            var repository = new TestContractPackageRepository();
            repository.Add(entities);
            return repository;
        }
    }
}