using DataPlatform.Shared.Helpers;
using NHibernate;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Infrastructure.Helpers;

namespace UserManagement.Infrastructure.Repositories
{
    public interface IContractRepository : IRepository<Contract>
    {
        PagedList<Contract> Search(string searchValue, int pageIndex, int pageSize);
    }

    public class ContractRepository : Repository<Contract>, IContractRepository
    {
        public ContractRepository(ISession session)
            : base(session)
        {
        }

        public PagedList<Contract> Search(string searchValue, int pageIndex, int pageSize)
        {
            var predicate = PredicateBuilder.False<Contract>();
            predicate = predicate.Or(x => (x.Name + "").Trim().ToLower().StartsWith((searchValue + "").Trim().ToLower()));
            predicate = predicate.Or(x => (x.Description + "").Trim().ToLower().StartsWith((searchValue + "").Trim().ToLower()));
            return new PagedList<Contract>(this, pageIndex, pageSize, predicate);
        }
    }
}