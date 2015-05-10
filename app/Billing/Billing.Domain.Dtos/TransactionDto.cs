using System;

namespace Billing.Domain.Dtos
{
    public class TransactionDto
    {
        public Guid TransactionId { get; set; }
        public bool IsBillable { get; set; }
    }
}