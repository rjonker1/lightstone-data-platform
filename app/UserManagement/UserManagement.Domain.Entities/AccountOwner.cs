using System;
using System.Collections.Generic;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public  class AccountOwner : Entity
    {

        public string Name { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Customer> Customer { get; set; }

        public AccountOwner()
        {
            Customer = new HashSet<Customer>();
        }

    }
}
