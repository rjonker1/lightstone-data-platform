using System.Collections.Generic;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class EscalationType : Entity
    {

        public virtual string Value { get; set; }
        public virtual ICollection<Contract> Contract { get; set; }

        public EscalationType()
        {
            Contract = new HashSet<Contract>();
        }

    }
}
