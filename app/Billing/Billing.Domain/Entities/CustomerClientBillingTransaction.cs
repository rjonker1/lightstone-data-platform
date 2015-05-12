using Billing.Domain.Dtos;

namespace Billing.Domain.Entities
{
    public class CustomerClientBillingTransaction<T> : ICommitBillingTransaction<CustomerClientTransactionDto> where T : class
    {
        public void Commit(CustomerClientTransactionDto entity)
        {
            throw new System.NotImplementedException();
        }
    }
}