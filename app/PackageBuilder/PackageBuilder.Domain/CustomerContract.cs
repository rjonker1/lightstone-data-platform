using System;
using DataPlatform.Shared.Entities;

namespace PackageBuilder.Domain
{
    public class CustomerContract : ICustomerContract
    {
        public Guid Id { get; set; }
        public ICustomer Customer { get; set; }
        public IContract Contract { get; set; }
        public DateTime ValidUntil { get; set; }

        public CustomerContract(ICustomer customer, IContract contract)
        {
            Customer = customer;
            Contract = contract;
        }
    }
}