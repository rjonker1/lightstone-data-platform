using System;
using System.ComponentModel.DataAnnotations;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class ClientUser : Entity
    {
        [Required]
        public virtual Client Client { get; protected internal set; }
        [Required]
        public virtual User User { get; protected internal set; }
        [Required]
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