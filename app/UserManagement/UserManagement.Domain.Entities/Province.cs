using System.Collections.Generic;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class Province : Entity
    {

        public virtual string Value { get; set; }
        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<Customer> Customer { get; set; }

        public Province()
        {
            Address = new HashSet<Address>();
            Customer = new HashSet<Customer>();
        }

    }
}
