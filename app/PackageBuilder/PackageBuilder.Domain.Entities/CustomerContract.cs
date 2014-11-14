using System;

namespace PackageBuilder.Domain.Entities
{
    public class CustomerContract : ICustomerContract
    {
        public Guid Id { get; private set; }
        public ICustomer Customer { get; set; }
        public IContract Contract { get; set; }
        public DateTime ValidUntil { get; set; }

        public CustomerContract(ICustomer customer, IContract contract)
        {
            Id = Guid.NewGuid();
            Customer = customer;
            Contract = contract;
        }
    }
}