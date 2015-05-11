using System.Collections.Generic;

namespace Billing.Domain.Dtos
{
    public class UserTransactionModelDto
    {
        public IEnumerable<TransactionDto> Transactions { get; set; } 
    }
}