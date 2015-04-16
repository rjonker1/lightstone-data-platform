using Billing.Domain.Core.Helpers;
using Billing.Domain.Core.Repositories;
using Billing.Domain.Entities;
using Billing.Infrastructure.Helpers;
using DataPlatform.Shared.Repositories;
using NHibernate;

namespace Billing.Infrastructure.Repositories
{
    public interface IPreBillingRepository : IRepository<Transaction>
    {
        PagedList<Transaction> Search(string searchValue, int pageIndex, int pageSize);
    }

    public class PreBillingRepository : Repository<Transaction>, IPreBillingRepository
    {
        public PreBillingRepository(ISession session)
            : base(session)
        {
        }

        public PagedList<Transaction> Search(string searchValue, int pageIndex, int pageSize)
        {
            var predicate = PredicateBuilder.False<Transaction>();
            //predicate = predicate.Or(x => (x.CustomerName + "").Trim().ToLower().StartsWith((searchValue + "").Trim().ToLower()));
            return new PagedList<Transaction>(this, pageIndex, pageSize, predicate);
        }
    }
}