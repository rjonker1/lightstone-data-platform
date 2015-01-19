using System;
using System.Collections.Generic;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public  class Client : Entity
    {

        public string ClientName { get; set; }
        public Guid? ClientProfileId { get; set; }

        public virtual ProfileDetail ProfileDetail { get; set; }
        public virtual ICollection<ClientPackage> ClientPackage { get; set; }
        public virtual ICollection<ClientUser> ClientUser { get; set; }
        public virtual ICollection<Contract> Contract { get; set; }

        public Client()
        {
            ClientPackage = new HashSet<ClientPackage>();
            ClientUser = new HashSet<ClientUser>();
            Contract = new HashSet<Contract>();
        }

    }
}
