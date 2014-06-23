using System;
using DataPlatform.Shared.Entities;

namespace PackageBuilder.Domain
{
    public class CustomerUser : ICustomerUser
    {
        public Guid Id { get; private set; }
        public ICustomer Customer { get; set; }
        public IUser User { get; set; }

        public CustomerUser(ICustomer customer, IUser user)
        {
            Id = Guid.NewGuid();
            Customer = customer;
            User = user;
        }
    }
}