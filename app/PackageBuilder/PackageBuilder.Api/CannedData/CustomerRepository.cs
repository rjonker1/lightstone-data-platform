using System.Linq;
using DataPlatform.Shared.Public;
using DataPlatform.Shared.Public.Entities;
using PackageBuilder.Api.Entities;

namespace PackageBuilder.Api.CannedData
{
    public interface ICustomerRepository : IRepository<ICustomer>
    {
        IUser GetUser(string username);
    }

    public class CustomerRepository : Repository<ICustomer>, ICustomerRepository
    {
        public CustomerRepository()
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