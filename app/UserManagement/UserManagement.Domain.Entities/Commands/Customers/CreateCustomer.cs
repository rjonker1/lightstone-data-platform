﻿using System.Collections.Generic;
using UserManagement.Domain.Core.Commands;

namespace UserManagement.Domain.Entities.Commands.Customers
{
    public class CreateCustomer : DomainCommand
    {
        public virtual string CustomerName { get; set; }
        public virtual string AccountOwnerName { get; set; }

        //public virtual Province Province { get; set; }
        //public virtual CustomerProfile CustomerProfile { get; set; }
        //public virtual IList<User> Users { get; set; }

        public CreateCustomer(string customerName, string accountOwnerName//, Province province
            //CustomerProfile customerProfile, IList<User> users
            )
        {
            CustomerName = customerName;
            AccountOwnerName = accountOwnerName;
            //Province = province;
            //CustomerProfile = customerProfile;
            //Users = users;
        }

    }
}