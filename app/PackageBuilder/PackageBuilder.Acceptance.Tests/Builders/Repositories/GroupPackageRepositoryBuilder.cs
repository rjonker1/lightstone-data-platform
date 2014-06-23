using DataPlatform.Shared.Entities;
using PackageBuilder.Acceptance.Tests.Fakes;
using PackageBuilder.Api.CannedData;

namespace PackageBuilder.Acceptance.Tests.Builders.Repositories
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