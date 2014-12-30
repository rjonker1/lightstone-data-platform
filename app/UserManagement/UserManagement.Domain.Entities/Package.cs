using System;
using System.Collections.Generic;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class Package : Entity
    {
        public Package()
        {
            this.ClientPackage = new HashSet<ClientPackage>();
        }

        public Guid ContractId { get; set; }
        public string LastUpdateBy { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public Nullable<bool> IsActivated { get; set; }

        public virtual ICollection<ClientPackage> ClientPackage { get; set; }
        public virtual Contract Contract { get; set; }
    }
}
