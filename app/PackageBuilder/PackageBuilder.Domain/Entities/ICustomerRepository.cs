using DataPlatform.Shared.Entities;
using DataPlatform.Shared.Repositories;

namespace PackageBuilder.Domain.Entities
{
    public interface ICustomerRepository : IRepository<ICustomer>
    {
        IUser GetUser(string username);
    }
}