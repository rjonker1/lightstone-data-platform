using DataPlatform.Shared.Helpers;
using NHibernate;
using UserManagement.Domain.Entities;
using UserManagement.Infrastructure.Helpers;

namespace UserManagement.Infrastructure.Repositories
{
    public interface IClientRepository : IRepository<Client>
    {
        PagedList<Client> Search(string searchValue, int pageIndex, int pageSize);
    }

    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(ISession session)
            : base(session)
        {
        }

        public PagedList<Client> Search(string searchValue, int pageIndex, int pageSize)
        {
            var predicate = PredicateBuilder.False<Client>();
            predicate = predicate.Or(x => (x.Name + "").Trim().ToLower().StartsWith((searchValue + "").Trim().ToLower()));
            return new PagedList<Client>(this, pageIndex, pageSize, predicate);
        }
    }
}