using PackageBuilder.Domain.Entities;
using Shared.Public.TestHelpers.Repositories;

namespace PackageBuilder.TestHelper.Fakes
{
    public class TestActionRepository : NamedCannedRepository<IAction>, IActionRepository
    {
         
    }
}