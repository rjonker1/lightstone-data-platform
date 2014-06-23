using DataPlatform.Shared.Entities;
using PackageBuilder.Acceptance.Tests.Fakes;
using PackageBuilder.Api.CannedData;

namespace PackageBuilder.Acceptance.Tests.Builders.Repositories
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