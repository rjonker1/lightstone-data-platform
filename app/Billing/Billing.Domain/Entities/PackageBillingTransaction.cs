using Billing.Domain.Dtos;

namespace Billing.Domain.Entities
{
    public class PackageBillingTransaction<T> : ICommitBillingTransaction<PackageTransactionDto> where T : class
    {
        public void Commit(PackageTransactionDto entity)
        {
            throw new System.NotImplementedException();
        }
    }
}