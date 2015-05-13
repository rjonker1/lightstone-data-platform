using System;

namespace Billing.Domain.Dtos
{
    public class CustomerClientTransactionDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}