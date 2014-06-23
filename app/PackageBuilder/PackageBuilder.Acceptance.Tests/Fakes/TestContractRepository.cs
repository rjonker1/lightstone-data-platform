using System.Linq;
using DataPlatform.Shared.Entities;
using PackageBuilder.Api.CannedData;
using Shared.Public.TestHelpers.Repositories;

namespace PackageBuilder.Acceptance.Tests.Fakes
{
    public class TestContractRepository : CannedRepository<IContract>, IContractRepository
    {
        public IContract First()
        {
            return Entities != null && Entities.Any() ? Entities.First() : null;
        }
    }
}