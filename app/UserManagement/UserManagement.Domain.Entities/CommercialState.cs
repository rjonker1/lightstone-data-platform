using System.Collections.Generic;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class CommercialState : Entity
    {

        public virtual string Value { get; set; }
        public virtual ICollection<CustomerProfile> CustomerProfile { get; set; }

        public CommercialState()
        {
            CustomerProfile = new HashSet<CustomerProfile>();
        }
    }
}
