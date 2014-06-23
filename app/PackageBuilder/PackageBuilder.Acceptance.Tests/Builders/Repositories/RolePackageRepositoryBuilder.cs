using DataPlatform.Shared.Entities;
using PackageBuilder.Acceptance.Tests.Fakes;
using PackageBuilder.Api.CannedData;

namespace PackageBuilder.Acceptance.Tests.Builders.Repositories
{
    public class RolePackageRepositoryBuilder
    {
        public static IRolePackageRepository Get(params IRolePackage[] entities)
        {
            var repository = new TestRolePackageRepository();
            repository.Add(entities);
            return repository;
        }
    }
}