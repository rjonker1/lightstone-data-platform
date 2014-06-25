using System.Linq;
using DataPlatform.Shared.Entities;
using PackageBuilder.Domain.Contracts;
using Shared.Public.TestHelpers.Repositories;

namespace PackageBuilder.TestHelper.Fakes
{
    public class TestContractRepository : CannedRepository<IContract>, IContractRepository
    {
        public IContract First()
        {
            return Entities != null && Entities.Any() ? Entities.First() : null;
        }
    }
}