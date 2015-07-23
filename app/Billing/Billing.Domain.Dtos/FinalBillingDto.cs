using System;
using System.Collections.Generic;
using Workflow.Billing.Domain.Entities;

namespace Billing.Domain.Dtos
{
    public class FinalBillingDto
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        public IEnumerable<User> Users { get; set; }
        public string Type { get; set; }
        public string Owner { get; set; }
        public int Products { get; set; }
        public int Transactions { get; set; }
        public int BilledTransactions { get; set; }
        public string UserType { get; set; }
        public int Total { get; set; }  
    }
}