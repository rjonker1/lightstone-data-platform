using System;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class ClientUser : Entity
    {
        public virtual Client Client { get; protected internal set; }
        public virtual User User { get; protected internal set; }
        public virtual string UserAlias { get; protected internal set; }

        protected ClientUser() { }

        public ClientUser(Client client, string userAlias) : base(Guid.NewGuid())
        {
            Client = client;
            UserAlias = userAlias;
        }

        public virtual void LinkUser(User user)
        {
            User = user;
        }
    }
}