using System.Collections.Generic;

namespace Billing.Domain.Dtos
{
    public class UserTransactionDto
    {
        public IEnumerable<TransactionDto> Transactions { get; set; } 
    }
}