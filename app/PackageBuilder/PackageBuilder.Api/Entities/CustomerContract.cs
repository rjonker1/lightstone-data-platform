using System;
using DataPlatform.Shared.Public.Entities;

namespace PackageBuilder.Api.Entities
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