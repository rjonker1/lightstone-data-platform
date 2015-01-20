using System;
using System.Collections.Generic;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class Package : Entity
    {

        public virtual string LastUpdateBy { get; set; }
        public virtual DateTime LastUpdateDate { get; set; }
        public virtual string Name { get; set; }
        public virtual string Version { get; set; }
        public virtual bool? IsActivated { get; set; }

        public virtual ICollection<ClientPackage> ClientPackage { get; set; }
        public virtual ICollection<ContractPackage> ContractPackage { get; set; }

        public Package()
        {
            ClientPackage = new HashSet<ClientPackage>();
            ContractPackage = new HashSet<ContractPackage>();
        }

    }
}
