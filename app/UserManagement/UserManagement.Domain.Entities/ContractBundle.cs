using System;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class ContractBundle : NamedEntity
    {
        public virtual double? Price { get; set; }
        public virtual int? TransactionLimit { get; set; }

        public ContractBundle() { }

        public ContractBundle(double price, int transactionLimit, string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
            TransactionLimit = transactionLimit;
        }
    }
}