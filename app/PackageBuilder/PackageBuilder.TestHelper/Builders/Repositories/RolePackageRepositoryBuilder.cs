using DataPlatform.Shared.Entities;
using PackageBuilder.Domain.Contracts;
using PackageBuilder.TestHelper.Fakes;

namespace PackageBuilder.TestHelper.Builders.Repositories
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