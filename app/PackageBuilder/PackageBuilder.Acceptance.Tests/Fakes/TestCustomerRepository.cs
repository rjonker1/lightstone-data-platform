using DataPlatform.Shared.Entities;
using PackageBuilder.Api.CannedData;
using Shared.Public.TestHelpers.Repositories;
using System.Linq;

namespace PackageBuilder.Acceptance.Tests.Fakes
{
    public class TestCustomerRepository : NamedCannedRepository<ICustomer>, ICustomerRepository
    {
        public IUser GetUser(string username)
        {
            return Entities.Select(c => c.Users.FirstOrDefault(u => u.Name == username)).FirstOrDefault();
        }
    }
}