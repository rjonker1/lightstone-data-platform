using DataPlatform.Shared.Entities;
using PackageBuilder.Domain.Contracts;
using PackageBuilder.TestHelper.Fakes;

namespace PackageBuilder.TestHelper.Builders.Repositories
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