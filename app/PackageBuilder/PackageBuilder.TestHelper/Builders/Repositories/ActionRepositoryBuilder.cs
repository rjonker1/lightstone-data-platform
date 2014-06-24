using DataPlatform.Shared.Entities;
using PackageBuilder.Domain.Contracts;
using PackageBuilder.TestHelper.Fakes;

namespace PackageBuilder.TestHelper.Builders.Repositories
{
    public class ActionRepositoryBuilder
    {
        public static IActionRepository Get(params IAction[] entities)
        {
            var repository = new TestActionRepository();
            repository.Add(entities);
            return repository;
        }
    }
}