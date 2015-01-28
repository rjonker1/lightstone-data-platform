using System;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class ClientUser : Entity
    {

        public virtual Client Client { get; set; }
        public virtual User User { get; set; }
        public virtual string UserAlias { get; set; }

        protected ClientUser() { }

        public ClientUser(Client client, User user, string userAlias)
        {
            Id = Guid.NewGuid();
            Client = client;
            User = user;
            UserAlias = userAlias;

        }
    }
}