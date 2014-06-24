using DataPlatform.Shared.Entities;
using PackageBuilder.Domain.Contracts;
using PackageBuilder.TestHelper.Fakes;

namespace PackageBuilder.TestHelper.Builders.Repositories
{
    public class ContractRepositoryBuilder
    {
        public static IContractRepository Get(params IContract[] entities)
        {
            var repository = new TestContractRepository();
            repository.Add(entities);
            return repository;
        }
    }
}