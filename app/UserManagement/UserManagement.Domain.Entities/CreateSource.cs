using System;
using System.Collections.Generic;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class CreateSource : Entity
    {

        public string Value { get; set; }
        public virtual ICollection<CustomerProfile> CustomerProfile { get; set; }

        public CreateSource()
        {
            CustomerProfile = new HashSet<CustomerProfile>();
        }

    }
}
