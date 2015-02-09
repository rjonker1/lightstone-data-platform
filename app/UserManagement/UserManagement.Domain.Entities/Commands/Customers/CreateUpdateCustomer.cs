using System;
using System.Collections.Generic;
using UserManagement.Domain.Core.Commands;

namespace UserManagement.Domain.Entities.Commands.Customers
{
    public class CreateUpdateCustomer : DomainCommand
    {
        public Guid Id;
        public string CustomerName;
        public string AccountOwnerName;

        public Province Province;
        //public virtual CustomerProfile CustomerProfile { get; set; }
        //public virtual IList<User> Users { get; set; }

        public CreateUpdateCustomer(string customerName, string accountOwnerName, Province province
            //CustomerProfile customerProfile, IList<User> users
            )
        {
            CustomerName = customerName;
            AccountOwnerName = accountOwnerName;
            Province = province;
            //CustomerProfile = customerProfile;
            //Users = users;
        }
        public CreateUpdateCustomer(Guid id, string customerName, string accountOwnerName, Province province
            //CustomerProfile customerProfile, IList<User> users
            )
        {
            Id = id;
            CustomerName = customerName;
            AccountOwnerName = accountOwnerName;
            Province = province;
            //CustomerProfile = customerProfile;
            //Users = users;
        }

    }
}