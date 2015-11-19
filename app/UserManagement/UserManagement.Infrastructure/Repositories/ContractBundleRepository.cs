using DataPlatform.Shared.Helpers;
using NHibernate;
using UserManagement.Domain.Entities;
using UserManagement.Infrastructure.Helpers;

namespace UserManagement.Infrastructure.Repositories
{

    public interface IContractBundleRepository : IRepository<ContractBundle>
    {
        PagedList<ContractBundle> Search(string searchValue, int pageIndex, int pageSize);
    }

    public class ContractBundleRepository : Repository<ContractBundle>, IContractBundleRepository
    {
        public ContractBundleRepository(ISession session)
            : base(session)
        {
        }

        public PagedList<ContractBundle> Search(string searchValue, int pageIndex, int pageSize)
        {
            var predicate = PredicateBuilder.False<ContractBundle>();
            predicate = predicate.Or(x => (x.Name + "").Trim().ToLower().StartsWith((searchValue + "").Trim().ToLower()));
            predicate = predicate.Or(x => (x.Price + "").Trim().ToLower().StartsWith((searchValue + "").Trim().ToLower()));
            predicate = predicate.Or(x => (x.TransactionLimit + "").Trim().ToLower().StartsWith((searchValue + "").Trim().ToLower()));
            return new PagedList<ContractBundle>(this, pageIndex, pageSize, predicate);
        }
    }
}