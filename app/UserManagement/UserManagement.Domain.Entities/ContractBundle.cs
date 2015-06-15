using System;

namespace UserManagement.Domain.Entities
{
    public class ContractBundle
    {
        public virtual Guid Id { get; set; }
        public virtual decimal Price { get; set; }
        public virtual int TransactionLimit { get; set; }
    }
}