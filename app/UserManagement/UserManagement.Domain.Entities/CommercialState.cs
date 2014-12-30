﻿using System.Collections.Generic;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class CommercialState : Entity
    {
        public CommercialState()
        {
            CustomerProfile = new HashSet<CustomerProfile>();
        }

        public string Value { get; set; }

        public virtual ICollection<CustomerProfile> CustomerProfile { get; set; }
    }
}
