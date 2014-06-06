using System;
using DataPlatform.Shared.Public.Entities;

namespace PackageBuilder.Api.Entities
{
    public class CustomerUser : ICustomerUser
    {
        public Guid Id { get; set; }
        public ICustomer Customer { get; set; }
        public IUser User { get; set; }

        public CustomerUser(ICustomer customer, IUser user)
        {
            Customer = customer;
            User = user;
        }
    }
}