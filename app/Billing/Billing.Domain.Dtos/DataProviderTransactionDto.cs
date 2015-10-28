using System;
using DataPlatform.Shared.Enums;

namespace Billing.Domain.Dtos
{
    public class DataProviderTransactionDto
    {
        public Guid Id { get; set; }
        public string DataProviderName { get; set; }
        public float CostPrice { get; set; }
        public float RecommendedPrice { get; set; }
        public DataProviderResponseState ResponseState { get; set; }
    }
}