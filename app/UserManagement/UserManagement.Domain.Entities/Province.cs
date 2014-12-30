using System;
using System.Collections.Generic;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class Province : Entity
    {
        public Province()
        {
            Customer = new HashSet<Customer>();
        }

        public string Value { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
    }
}
