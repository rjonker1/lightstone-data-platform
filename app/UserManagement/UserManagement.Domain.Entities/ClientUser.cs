using System;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class ClientUser : Entity
    {

        public virtual string UserAlias { get; set; }

        public virtual Client Client { get; set; }
        public virtual User User { get; set; }

        protected ClientUser() { }

        public ClientUser(string userAlias, Client client, User user)
        {
            Id = Guid.NewGuid();
            UserAlias = userAlias;
            Client = client;
            User = user;
        }
    }
}