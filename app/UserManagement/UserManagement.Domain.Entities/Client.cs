using System;
using System.Collections.Generic;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public  class Client : Entity
    {
        public virtual string ClientName { get; protected internal set; }
        public virtual IEnumerable<Package> Packages { get; protected internal set; } 
        //public virtual Guid? ClientProfileId { get; set; }

        //public virtual ProfileDetail ProfileDetail { get; set; }

        public virtual IEnumerable<ClientUser> ClientUsers { get; protected internal set; }

        protected Client() { }

        public Client(Guid id, string clientName) : base(id)
        {
            ClientName = clientName;
            //ClientUsers = new Collection<ClientUser>();
        }

        public virtual void UpdateName(string name)
        {
            ClientName = name;
        }
    }
}
