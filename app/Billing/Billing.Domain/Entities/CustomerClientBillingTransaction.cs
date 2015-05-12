namespace Billing.Domain.Entities
{
    public class CustomerClientBillingTransaction<T> : ICommitBillingTransaction<T> where T : class
    {
        public void Commit(T entity)
        {
            throw new System.NotImplementedException();
        }
    }
}