using System;

namespace UserManagement.Domain.Entities
{
    public class ContractBundle : NamedEntity
    {
        public virtual double Price { get; protected internal set; }
        public virtual int TransactionLimit { get; protected internal set; }

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