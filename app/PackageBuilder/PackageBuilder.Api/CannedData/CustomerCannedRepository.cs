using System.Linq;
using DataPlatform.Shared.Entities;
using DataPlatform.Shared.Repositories;
using PackageBuilder.Domain;
using Shared.Public.TestHelpers.Repositories;

namespace PackageBuilder.Api.CannedData
{
    public interface ICustomerRepository : IRepository<ICustomer>
    {
        IUser GetUser(string username);
    }

    public class CustomerCannedRepository : CannedRepository<ICustomer>, ICustomerRepository
    {
        public CustomerCannedRepository()
        {
            var customer = new Customer("WesBank");
            customer.Add(new User("admin"));
            Add(customer);
        }

        public IUser GetUser(string username)
        {
            return Entities.Select(c => c.Users.FirstOrDefault(u => u.Name == username)).FirstOrDefault();
        }
    }
}