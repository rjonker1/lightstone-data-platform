using System;

namespace UserManagement.Domain.Entities
{
    class ClientUser
    {

        public Guid Id { get; protected internal set; }
        public IUser User { get; set; }

        public ClientUser(IUser user, IRole role)
        {
            Id = new Guid();
            User = user;
            Role = role;
        }

    }
}
