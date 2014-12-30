using System;
using System.Collections.Generic;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class CreateSource : Entity
    {
        public CreateSource()
        {
            CustomerProfile = new HashSet<CustomerProfile>();
        }

        public string Value { get; set; }

        public virtual ICollection<CustomerProfile> CustomerProfile { get; set; }
    }
}
