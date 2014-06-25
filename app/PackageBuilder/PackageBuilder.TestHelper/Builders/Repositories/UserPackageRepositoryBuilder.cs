using DataPlatform.Shared.Entities;
using PackageBuilder.Domain.Contracts;
using PackageBuilder.TestHelper.Fakes;

namespace PackageBuilder.TestHelper.Builders.Repositories
{
    public class UserPackageRepositoryBuilder
    {
        public static IUserPackageRepository Get(params IUserPackage[] entities)
        {
            var repository = new TestUserPackageRepository();
            repository.Add(entities);
            return repository;
        }
    }
}