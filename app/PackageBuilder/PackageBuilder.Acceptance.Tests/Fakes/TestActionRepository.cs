using DataPlatform.Shared.Entities;
using PackageBuilder.Api.CannedData;
using Shared.Public.TestHelpers.Repositories;

namespace PackageBuilder.Acceptance.Tests.Fakes
{
    public class TestActionRepository : NamedCannedRepository<IAction>, IActionRepository
    {
         
    }
}