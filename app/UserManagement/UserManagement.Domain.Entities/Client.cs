using System;
using System.Collections.Generic;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public  class Client : Entity
    {
        public virtual string ClientName { get; protected internal set; }
        public virtual ContactDetail ContactDetail { get; protected internal set; }
        public virtual ISet<Package> Packages { get; protected internal set; }
        public virtual ISet<ClientUser> ClientUsers { get; protected internal set; }

        public Client() { }

        public Client(string clientName, Guid id = new Guid()) : base(id)
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
