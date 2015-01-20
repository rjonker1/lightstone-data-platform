using System;
using System.Collections.Generic;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class ContractDuration : Entity
    {

        public virtual string Value { get; set; }
        public virtual ICollection<Contract> Contract { get; set; }

        public ContractDuration()
        {
            Contract = new HashSet<Contract>();
        }
    }
}
