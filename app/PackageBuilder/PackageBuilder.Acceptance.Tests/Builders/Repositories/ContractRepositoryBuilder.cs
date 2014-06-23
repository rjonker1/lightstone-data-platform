using DataPlatform.Shared.Entities;
using PackageBuilder.Acceptance.Tests.Fakes;
using PackageBuilder.Api.CannedData;

namespace PackageBuilder.Acceptance.Tests.Builders.Repositories
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