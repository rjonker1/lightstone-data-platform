namespace Billing.Domain.Entities
{
    public class PackageBillingTransaction<T> : ICommitBillingTransaction<T> where T : class
    {
        public void Commit(T entity)
        {
            throw new System.NotImplementedException();
        }
    }
}