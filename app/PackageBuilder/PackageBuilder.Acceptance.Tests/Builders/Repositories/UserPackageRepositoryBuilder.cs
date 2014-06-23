using DataPlatform.Shared.Entities;
using PackageBuilder.Acceptance.Tests.Fakes;
using PackageBuilder.Api.CannedData;

namespace PackageBuilder.Acceptance.Tests.Builders.Repositories
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