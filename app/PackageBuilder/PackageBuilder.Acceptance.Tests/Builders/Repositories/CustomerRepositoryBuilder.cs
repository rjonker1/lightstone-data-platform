using DataPlatform.Shared.Entities;
using PackageBuilder.Acceptance.Tests.Fakes;
using PackageBuilder.Api.CannedData;

namespace PackageBuilder.Acceptance.Tests.Builders.Repositories
{
    public class CustomerRepositoryBuilder
    {
        public static ICustomerRepository Get(params ICustomer[] entities)
        {
            var repository = new TestCustomerRepository();
            repository.Add(entities);
            return repository;
        }
    }
}