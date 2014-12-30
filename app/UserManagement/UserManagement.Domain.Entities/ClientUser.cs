using System;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class ClientUser : Entity
    {
        public Guid ClientId { get; set; }
        public Guid UserId { get; set; }
        public string Alias { get; set; }

        public virtual Client Client { get; set; }
        public virtual User User { get; set; }
    }
}




//public Guid Id { get; protected internal set; }
//        public IUser User { get; set; }

//        public ClientUser(IUser user, IRole role)
//        {
//            Id = new Guid();
//            User = user;
//            Role = role;
//        }