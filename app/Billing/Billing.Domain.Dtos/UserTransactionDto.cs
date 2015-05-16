using System.Collections.Generic;

namespace Billing.Domain.Dtos
{
    public class UserTransactionDto
    {
        public string UserName { get; set; }
        public IEnumerable<TransactionDto> Transactions { get; set; } 
    }
}