using System;
using System.Collections.Generic;
using Workflow.Billing.Domain.Dtos;
using Workflow.Billing.Domain.Entities;

namespace Billing.Domain.Dtos
{
    public class PreBillingDto
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        public int Users { get; set; }
        public string Type { get; set; }
        public string Owner { get; set; }
        public int Products { get; set; }
        public IEnumerable<PackageDto> ProductsDetail { get; set; }
        public int Transactions { get; set; }
        public string UserType { get; set; }
        public AccountMeta AccountMeta { get; set; }
        public int Total { get; set; } 
    }

}