using System;

namespace Workflow.Billing.Domain.Dtos
{
    public class TransactionDto
    {
        public DateTime? Created { get; set; }
        public Guid TransactionId { get; set; }
        public Guid RequestId { get; set; }
        public bool IsBillable { get; set; }
    }
}