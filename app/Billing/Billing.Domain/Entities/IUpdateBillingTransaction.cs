using DataPlatform.Shared.Repositories;

namespace Billing.Domain.Entities
{
    public interface IUpdateBillingTransaction<in T> where T: class
    {
        void Commit(T entity);
    }
}