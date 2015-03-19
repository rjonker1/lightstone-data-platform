using Billing.Domain.Core.Helpers;
using Billing.Domain.Core.Repositories;
using Billing.Domain.Entities;
using Billing.Infrastructure.Helpers;
using NHibernate;

namespace Billing.Infrastructure.Repositories
{
    public interface IPreBillingRepository : IRepository<PreBilling>
    {
        PagedList<PreBilling> Search(string searchValue, int pageIndex, int pageSize);
    }

    public class PreBillingRepository : Repository<PreBilling>, IPreBillingRepository
    {
        public PreBillingRepository(ISession session)
            : base(session)
        {
        }

        public PagedList<PreBilling> Search(string searchValue, int pageIndex, int pageSize)
        {
            var predicate = PredicateBuilder.False<PreBilling>();
            //predicate = predicate.Or(x => (x.CustomerName + "").Trim().ToLower().StartsWith((searchValue + "").Trim().ToLower()));
            return new PagedList<PreBilling>(this, pageIndex, pageSize, predicate);
        }
    }
}