using System;
using System.Collections.Generic;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class Package : Entity
    {

        public string LastUpdateBy { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public bool? IsActivated { get; set; }

        public virtual ICollection<ClientPackage> ClientPackage { get; set; }
        public virtual ICollection<ContractPackage> ContractPackage { get; set; }

        public Package()
        {
            ClientPackage = new HashSet<ClientPackage>();
            ContractPackage = new HashSet<ContractPackage>();
        }

    }
}
