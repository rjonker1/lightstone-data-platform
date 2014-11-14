using PackageBuilder.Core.Repositories;

namespace PackageBuilder.Domain.Entities
{
    public interface ICustomerRepository : IRepository<ICustomer>
    {
        IUser GetUser(string username);
    }
}