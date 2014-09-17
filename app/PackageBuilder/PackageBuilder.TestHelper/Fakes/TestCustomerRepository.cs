using DataPlatform.Shared.Entities;
using PackageBuilder.Domain.Entities;
using Shared.Public.TestHelpers.Repositories;
using System.Linq;

namespace PackageBuilder.TestHelper.Fakes
{
    public class TestCustomerRepository : NamedCannedRepository<ICustomer>, ICustomerRepository
    {
        public IUser GetUser(string username)
        {
            return Entities.Select(c => c.Users.FirstOrDefault(u => u.Name == username)).FirstOrDefault();
        }
    }
}