using System;

namespace Billing.Domain.Dtos
{
    public class DataProviderTransactionDto
    {
        public Guid Id { get; set; }
        public string DataProviderName { get; set; }
        public float CostPrice { get; set; }
        public float RecommendedPrice { get; set; }
    }
}