using PackageBuilder.Domain.Contracts;
using PackageBuilder.TestHelper.Fakes;

namespace PackageBuilder.TestHelper.Builders.Repositories
{
    public class GroupPackageRepositoryBuilder
    {
        public static IGroupPackageRepository Get(params IGroupPackage[] entities)
        {
            var repository = new TestGroupPackageRepository();
            repository.Add(entities);
            return repository;
        }
    }
}