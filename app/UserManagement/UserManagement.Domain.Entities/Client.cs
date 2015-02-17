using System.Collections.Generic;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public  class Client : NamedEntity
    {
        public virtual ContactDetail ContactDetail { get; protected internal set; }
        public virtual ISet<Package> Packages { get; protected internal set; }
        public virtual ISet<ClientUser> ClientUsers { get; protected internal set; }

        public Client() { }

        public Client(string clientName) : base(clientName)
        {
        }
    }
}
