
namespace Billing.Domain.Entities
{
    public interface ICommitBillingTransaction<in T> where T: class
    {
        void Commit(T entity);
    }
}