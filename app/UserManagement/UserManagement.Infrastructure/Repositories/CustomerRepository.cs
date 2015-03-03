using NHibernate;
using UserManagement.Domain.Core.Helpers;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Infrastructure.Helpers;

namespace UserManagement.Infrastructure.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        PagedList<Customer> Search(string searchValue, int pageIndex, int pageSize);
    }

    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ISession session) : base(session)
        {
        }

        public PagedList<Customer> Search(string searchValue, int pageIndex, int pageSize)
        {
            var predicate = PredicateBuilder.False<Customer>();
            predicate = predicate.Or(x => (x.Name + "").Trim().ToLower().StartsWith((searchValue + "").Trim().ToLower()));
            predicate = predicate.Or(x => (x.AccountOwnerName + "").Trim().ToLower().StartsWith((searchValue + "").Trim().ToLower()));
            return new PagedList<Customer>(this, pageIndex, pageSize, predicate);
        }
    }
}